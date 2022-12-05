using CatsGrpcMicroservice.Commands;
using CatsGrpcMicroservice.Entities;
using CatsGrpcMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace CatsGrpcMicroservice.Repositories
{
    public class CatsGrpcRepository:ICatsGrpcRepository
    {
        private readonly CatsDbContext _context;
        private readonly IDistributedCache _cache;
        public CatsGrpcRepository(CatsDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<double> CreateCats(CreateCatsCommand command)
        {
            Employee employee = await _context.Employees.SingleAsync<Employee>(r => r.UserId == command.UserId);
            Cat? userCat;
            bool catExist = await _context.Cats.AnyAsync(c => c.EmployeeId == employee.EmployeeId && c.CatCreated == command.EntryDate);
            if (catExist)
            {
                userCat = await _context.Cats.SingleAsync(c => c.EmployeeId == employee.EmployeeId && c.CatCreated == command.EntryDate);    
            }
            else
            {
                userCat = new Cat()
                {
                    CatCreated = command.EntryDate,
                    EmployeeId = employee.EmployeeId,
                };
                await _context.Cats.AddAsync(userCat);
                await _context.SaveChangesAsync();
            }

            CatRecord? catRecord;
            bool recordExist = await _context.CatRecords.AnyAsync(r => r.InboxItemId == command.InboxItemId);
            if (recordExist)
            {
                catRecord = await _context.CatRecords.SingleAsync(r => r.InboxItemId == command.InboxItemId);
            }
            else 
            {
                catRecord = new CatRecord()
                {
                    CatId = userCat.CatId,
                    InboxItemId = command.InboxItemId,
                    Receiver = "RECEIVER DEPEND",
                    SapText = $"NA_{command.ProjectNumber}_{command.Client}_{command.ProjectName}",
                };
                await _context.CatRecords.AddAsync(catRecord);
                await _context.SaveChangesAsync();

            }

            CatRecordHours? catRecordHour;
            bool hoursExits = await _context
                .CatRecordHourss
                .AnyAsync(c => c.CatRecordId == catRecord.CatRecordId
                && c.Date == command.EntryDate);

            if (hoursExits) 
            {
                catRecordHour = await _context
                .CatRecordHourss
                .SingleAsync(c => c.CatRecordId == catRecord.CatRecordId
                && c.Date == command.EntryDate);
                catRecordHour.Hours = command.Hours;
            }
            else
            {
                catRecordHour = new CatRecordHours()
                {
                    CatRecordId = catRecord.CatRecordId,
                    Hours = command.Hours,
                    Date = command.EntryDate
                };
                await _context.CatRecordHourss.AddAsync(catRecordHour);
            }
            await _context.SaveChangesAsync();
            return catRecord.CatRecordHours.Sum(h => h.Hours);
        }

        public async Task<double> DeleteCats(DeleteCatsCommand command)
        {
            CatRecord catRecord = await _context.CatRecords.SingleAsync(r => r.InboxItemId == command.InboxItemId);

            if (catRecord is null) throw new BadHttpRequestException("Cat not found");

            CatRecordHours catRecordHour = await _context.CatRecordHourss
                .SingleAsync(h => h.CatRecordId == catRecord.CatRecordId &&
                h.Date == command.EntryDate);
            _context.CatRecordHourss.Remove(catRecordHour);
            return catRecord.CatRecordHours.Sum(h => h.Hours);
        }





        public async Task<Employee> CreateEmployee(CreateEmployeeCommand command)
        {
            Employee newEmployee = new Employee()
            {
                UserId = command.UserId,
                Name = command.Name,
                CCtr = command.CCtr,
                ActTyp = command.ActTyp,
            };
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            return newEmployee;
        }

        

        public async Task<bool> DeleteEmployee(DeleteEmployeeCommand command)
        {

            Employee deletedEmployee = await _context.Employees.SingleAsync(e => e.UserId == command.UserId);
            if (deletedEmployee == null) throw new BadHttpRequestException("Bad request");
            _context.Employees.Remove(deletedEmployee);
            await _context.SaveChangesAsync();
            return true;
        }

      

        public async Task<Employee> UpdateEmployee(UpdateEmployeeCommand command)
        {
            Employee updatedEmployee = await _context.Employees.SingleAsync(e => e.UserId == command.UserId);
            updatedEmployee.Name = command.Name;
            updatedEmployee.CCtr = command.CCtr;
            updatedEmployee.ActTyp = command.ActTyp;
            await _context.SaveChangesAsync();
            return updatedEmployee;
        }
    }
}
