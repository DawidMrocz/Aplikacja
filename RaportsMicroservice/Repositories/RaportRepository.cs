using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.VisualBasic;
using RaportMicroservice.Models;
using RaportMicroservice.Queries;
using RaportsMicroservice.Commands.RaportCommands;
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

        public async Task<UserRaport> CreateRaport(CreateRaportCommand command)
        {
            Raport raport = await _context.Raports.SingleAsync<Raport>(r => r.Created == DateTime.Now.ToString("yyyy MM"));
            if(raport is null)
            {
                raport = new Raport()
                {
                    TotalHours = 0,
                    Created = DateTime.Now.ToString("yyyy MM"),
                };
                await _context.Raports.AddAsync(raport);
            }

            UserRaport myUserRaport = await _context.UserRaports.SingleAsync(uR => uR.RaportId == raport.RaportId && uR.UserId == command.UserId);
            if (myUserRaport is null)
            {
                myUserRaport = new UserRaport()
                {
                    UserId = command.UserId,
                    Name = command.Name,
                    UserAllHours = command.Hours
                };
                await _context.UserRaports.AddAsync(myUserRaport);
            }

            UserRaportRecord userRaportRecord = await _context.UserRaportRecords.SingleAsync(
                    record => record.ProjectNumber == command.ProjectNumber &&
                    record.Ecm == command.Ecm &&
                    record.Gpdm == command.Gpdm);

            if(userRaportRecord is null)
            {
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
                userRaportRecord.System = command.System;
                userRaportRecord.Ecm = command.Ecm;
                userRaportRecord.Gpdm = command.Gpdm;
                userRaportRecord.ProjectNumber = command.ProjectNumber;
                userRaportRecord.Components = command.Components;
                userRaportRecord.DrawingsOfComponents = command.DrawingOfComponent;
                userRaportRecord.DrawingsOfAssemblies = command.DrawingOfAssemblies;
                userRaportRecord.Started = command.StartedDate;
                userRaportRecord.Finished = command.FinishedDate;
                userRaportRecord.DueDate = command.DueDate;
                userRaportRecord.TaskHours = command.Hours;
                userRaportRecord.UserRaportId = myUserRaport.RaportId;
            }        
            myUserRaport.UserAllHours = myUserRaport.UserRaportRecords.Sum(h => h.TaskHours);
            raport.TotalHours = raport.UserRaports.Sum(h => h.UserAllHours);
            return myUserRaport; 
        }

        public async Task<bool> DeleteRaport(DeleteRaportCommand command)
        {
            Raport raport = await _context.Raports.SingleAsync(d => d.Created == DateTime.Now.ToString("yyyy MM"));
            UserRaport userRaport = await _context.UserRaports.SingleAsync(r => r.RaportId == raport.RaportId && r.UserId == command.UserId);
            UserRaportRecord recordToDelete = await _context.UserRaportRecords.SingleAsync(r => r.InboxItemId == command.InboxItemId && r.UserRaportId == userRaport.UserRaportId);
            if (recordToDelete == null) throw new BadHttpRequestException("Bad request");
            _context.UserRaportRecords.Remove(recordToDelete);
            userRaport.UserAllHours = userRaport.UserRaportRecords.Sum(h => h.TaskHours);
            raport.TotalHours = raport.UserRaports.Sum(h => h.UserAllHours);
            await _context.SaveChangesAsync();
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
    }
}