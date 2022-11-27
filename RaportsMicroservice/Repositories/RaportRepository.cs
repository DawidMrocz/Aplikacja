using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using RaportMicroservice.Models;
using RaportMicroservice.Queries;
using RaportsMicroservice.Commands;
using RaportsMicroservice.Entities;
using RaportsMicroservice.Extensions;
using RaportsMicroservice.Queries;

namespace RaportsMicroservice.Repositories
{
    public class RaportRepository : IRaportRepository
    {
        private readonly RaportDbContext _context;
        private readonly IDistributedCache _cache;
        public RaportRepository(RaportDbContext context, IDistributedCache cache)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<UserRaport> AddUserRaportRecord(AddUserRaportRecordCommand command)
        {
            Raport raport = await _context.Raports.SingleAsync<Raport>(r => r.Created == command.SendDate);
            if(raport is null)
            {
                raport = new Raport()
                {
                    TotalHours = 0,
                    Created = command.SendDate,
                };
                await _context.Raports.AddAsync(raport);
            }

            UserRaport myUserRaport = await _context.UserRaports.SingleAsync(uR => uR.RaportId == raport.RaportId && uR.UserId == command.UserId);
            if(myUserRaport is null)
            {
                myUserRaport = new UserRaport()
                {
                    UserId = command.UserId,
                    Name = command.Name,
                    UserAllHours = command.Hours
                };
                await _context.UserRaports.AddAsync(myUserRaport);
                myUserRaport.UserRaportRecords = new List<UserRaportRecord>()
                {
                    new UserRaportRecord()
                    {  
                        System = command.System,
                        Ecm = command.Ecm,
                        Gpdm = command.Gpdm,
                        ProjectNumber = command.ProjectNumber,
                        Components = command.Components,
                        DrawingsOfComponents = command.DrawingOfComponent,
                        DrawingsOfAssemblies = command.DrawingOfAssemblies,
                        Started = command.StartedDate,
                        Finished = command.FinishedDate,
                        DueDate = command.DueDate,
                        TaskHours = command.Hours,
                        UserRaportId =  myUserRaport.RaportId
                    }
                };
            }
            else
            {
                UserRaportRecord userRaportRecord = await _context.UserRaportRecords.SingleAsync(
                    record => record.ProjectNumber == command.ProjectNumber && 
                    record.Ecm == command.Ecm && 
                    record.Gpdm == command.Gpdm);
                if(userRaportRecord is null)
                {
                    myUserRaport.UserRaportRecords.Add(userRaportRecord);
                }
                else
                {
                    userRaportRecord.TaskHours = command.Hours;
                }
            }
            myUserRaport.UserAllHours = myUserRaport.UserRaportRecords.Sum(h => h.TaskHours);
            raport.TotalHours = raport.UserRaports.Sum(h => h.UserAllHours);
            return myUserRaport; 
        }

        public async Task<UserRaportRecord> UpdateUserRaportRecord(UpdateUserRaportRecordCommand command)
        {
            UserRaportRecord userRaportRecord = await _context.UserRaportRecords.SingleAsync(r => r.UserRaportRecordId == command.UserRecordId);
            userRaportRecord.System = command.System;
            userRaportRecord.Ecm = command.Ecm;
            userRaportRecord.Gpdm = command.Gpdm;
            userRaportRecord.ProjectNumber = command.ProjectNumber;
            userRaportRecord.Components = command.DrawingOfComponent;
            userRaportRecord.DrawingsOfComponents = command.DrawingOfComponent;
            userRaportRecord.DrawingsOfAssemblies = command.DrawingOfAssemblies;
            userRaportRecord.Started = command.StartedDate;
            userRaportRecord.Finished = command.FinishedDate;
            userRaportRecord.DueDate = command.DueDate;
            userRaportRecord.TaskHours = command.TaskHours;
            
            Raport raport = await _context.Raports.SingleAsync(r => r.RaportId == command.RaportId);
            foreach(UserRaport user in raport.UserRaports)
            {
                if(user.UserRaportId == command.UserId) user.UserAllHours = user.UserRaportRecords.Sum(h => h.TaskHours);
            }
            raport.TotalHours = raport.UserRaports.Sum(h => h.UserAllHours);

            await _context.SaveChangesAsync();

            return userRaportRecord;
        }

        public async Task<bool> DeleteUserRaportRecord(DeleteUserRaportRecordCommand command)
        {
            UserRaportRecord recordToDelete = await _context.UserRaportRecords.SingleAsync(r => r.UserRaportRecordId == command.UserRaportRecordId);
            if (recordToDelete == null) throw new BadHttpRequestException("Bad request");
            _context.UserRaportRecords.Remove(recordToDelete);
            return true;
        }

        public async Task<Raport> GetRaport(GetRaportQuery query)
        {
            Raport? raport = await _cache.GetRecordAsync<Raport>($"Raport_{query.RaportId}");
            if (raport is null)
            {
                raport = await _context.Raports.SingleAsync(r => r.RaportId == query.RaportId);
                if (raport is null) throw new BadHttpRequestException("Bad request");
                await _cache.SetRecordAsync($"Raport_{query.RaportId}", raport);
            }
            return raport;
        }

        public async Task<List<Raport>> GetRaports(GetRaportsQuery query)
        {
            List<Raport>? raports = await _cache.GetRecordAsync<List<Raport>>($"Raports");
            if (raports is null)
            {
                raports = await _context.Raports.AsNoTracking().ToListAsync();
                if (raports is null) throw new BadHttpRequestException("Bad request");
                await _cache.SetRecordAsync($"Raports", raports);
            }
            return raports;
        }

        public async Task<UserRaport> UpdateUserRaport(UpdateUserRaportCommand command)
        {
            UserRaport user = await _context.UserRaports.SingleAsync(u => u.UserId == command.UserId);
            if (user is null) throw new BadHttpRequestException("Bad request");
            user.Name = command.Name;
            await _cache.DeleteRecordAsync<UserRaport>($"Raport_{user.RaportId}");
            return user;
        }
    }
}