using CatsApiMicroservice.Queries;
using CatsApiMicroservice.Entities;
using CatsApiMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using CatsApiMicroservice.Queries.CatQueries;
using CatsApiMicroservice.Queries.EmployeeQueries;
using CatsApiMicroservice.Commands.CatRecordCommands;
using CatsApiMicroservice.Commands.CatRecordHoursCommands;

namespace CatsApiMicroservice.Repositories
{
    public class UserCatsRepository : IUserCatsRepository
    {
        private readonly UserCatsDbContext _context;
        private readonly IDistributedCache _cache;
        public UserCatsRepository(UserCatsDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<bool> DeleteCatRecord(DeleteCatRecordCommand command)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCatRecordHours(DeleteCatRecordHoursCommand command)
        {
            throw new NotImplementedException();
        }

        public async Task<Cat> GetCat(GetCatQuery query)
        {
            Employee employee = await _context.Employees.SingleAsync(i => i.UserId == query.UserId);
            
            Cat cat = await _context.Cats
                .Include(r => r.CatRecords)
                .ThenInclude(h => h.CatRecordHours)
                .AsNoTracking()
                .SingleAsync(c => c.CatId == query.CatId);

            if (cat.EmployeeId != employee.EmployeeId) throw new BadHttpRequestException("You are not authenticated");

            return cat;
        }

        public async Task<Employee> GetEmployee(GetEmployeeQuery query)
        {
            return await _context.Employees.Include(c => c.Cats).AsNoTracking().SingleAsync(c => c.UserId == query.UserId);
        }

        public async Task<CatRecord> UpdateCatRecord(UpdateCatRecordCommand command)
        {
            throw new NotImplementedException();
        }

        public async Task<CatRecordHours> UpdateCatRecordHours(UpdateCatRecordHoursCommand command)
        {
            throw new NotImplementedException();
        }
    } 
}
