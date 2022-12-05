using CatsGrpcMicroservice.Protos;
using InboxMicroservice.Commands.CatsCommands;
using InboxMicroservice.Commands.FromJobsCommands;
using InboxMicroservice.Commands.InboxCommands;
using InboxMicroservice.Commands.InboxItemCommands;
using InboxMicroservice.Contracts.InboxItemContracts;
using InboxMicroservice.Contracts.RaportContracts;
using InboxMicroservice.Dtos;
using InboxMicroservice.Entities;
using InboxMicroservice.GrpcSerivce;
using InboxMicroservice.Models;
using InboxMicroservice.Queries;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace InboxMicroservice.Repositories
{
    public class InboxRepository : IInboxRepository
    {
        private readonly InboxDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ICatsGrpcService _catsGrpcService;

        public InboxRepository(InboxDbContext context, IPublishEndpoint publishEndpoint, ICatsGrpcService catsGrpcService)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
            _catsGrpcService = catsGrpcService;
        }

        public async Task<Inbox> GetMyInbox(GetMyInboxQuery query)
        {
            Inbox myInbox =  await _context.Inboxs
                .Include(i => i.InboxItems)
                .AsNoTracking()
                .SingleAsync(i => i.UserId == query.UserId);
            if (myInbox is null) throw new BadHttpRequestException("Inbox don't exist");
            return myInbox;
        }

        public async Task<InboxItem> CreateInboxItemFromJobs(CreateInboxItemFromJobCommand command)
        {
            Inbox InboxUser = await _context.Inboxs.SingleAsync(u => u.UserId == command.UserId);
            if (InboxUser is null) throw new BadHttpRequestException("Inbox don't exist");
            InboxItem newInboxItem = new InboxItem()
            {
                InboxId = InboxUser.InboxId,
                JobId = command.JobId,
                JobDescription = command.JobDescription,
                Type = command.Type,
                System = command.System,
                Link = command.Link,
                Engineer = command.Engineer,
                Ecm = command.Ecm,
                Gpdm = command.Gpdm,
                ProjectNumber = command.ProjectNumber,
                Client = command.Client,
                ProjectName = command.ProjectName,
                Status = command.Status,
                DueDate = command.DueDate,
                Received = command.Received
            };
            await _context.InboxItems.AddAsync(newInboxItem);
            await _context.SaveChangesAsync();
            return newInboxItem;
        }

        public async Task<List<InboxItem>> UpdateInboxItemFromJobs(UpdateInboxItemFromJobCommand command)
        {
            var inboxItem = await _context.InboxItems.Where(i => i.JobId == command.JobId).ToListAsync();
            foreach (var item in inboxItem)
            {
                item.JobDescription = command.JobDescription;
                item.Type = command.Type;
                item.System = command.System;
                item.Link = command.Link;
                item.Engineer = command.Engineer;
                item.Ecm = command.Ecm;
                item.Gpdm = command.Gpdm;
                item.ProjectNumber = command.ProjectNumber;
                item.Client = command.Client;
                item.ProjectName = command.ProjectName;
                item.Status = command.Status;
                item.DueDate = command.DueDate;
                item.Received = command.Received;
            }
            await _context.SaveChangesAsync();
            return inboxItem;
        }

        public async Task<bool> DeleteInboxItemFromJobs(DeleteInboxItemFromJobCommand command)
        {
            var productsToDelete = await _context.InboxItems.Where(p => p.InboxId == command.JobId).ToListAsync();
            _context.InboxItems.RemoveRange(productsToDelete);
            await _context.SaveChangesAsync();
            return true;
        }




        public async Task<InboxItem> UpdateInboxItem(UpdateInboxItemCommand command)
        {
            InboxItem inboxItem = await _context.InboxItems.SingleAsync(i => i.InboxItemId == command.InboxItemId);
            if (inboxItem is null) throw new BadHttpRequestException("Item not found!");
            inboxItem.Status = command.Status;
            inboxItem.Components = command.Components;
            inboxItem.DrawingsComponents = command.DrawingsComponents;
            inboxItem.DrawingsAssembly = command.DrawingsAssembly;
            inboxItem.WhenComplete = command.WhenComplete;
            inboxItem.Started = command.Started;
            inboxItem.Finished = command.Finished;

            UpdateInboxItemFromInbox updateInboxItemFromInbox = new UpdateInboxItemFromInbox
            (
                inboxItem.JobId,
                command.Status,
                command.WhenComplete,
                command.Started,
                command.Finished
            );

            await _publishEndpoint.Publish(updateInboxItemFromInbox);
            await _context.SaveChangesAsync();
            return inboxItem;
        }

        public async Task<bool> DeleteInboxItem(DeleteInboxItemCommand command)
        {
            InboxItem inboxItem = await _context.InboxItems.SingleAsync(i => i.InboxItemId == command.InboxItemId);

            DeleteInboxItemFromInbox deleteInboxItemFromInbox = new DeleteInboxItemFromInbox
            (
                inboxItem.JobId,
                command.UserId
            );
            DeleteRaport deleteRaport = new DeleteRaport
            (
                inboxItem.InboxItemId
            );
            _context.InboxItems.Remove(inboxItem);
            await _context.SaveChangesAsync();
            await _publishEndpoint.Publish(deleteInboxItemFromInbox);
            await _publishEndpoint.Publish(deleteRaport);
            return true;
        }



        public async Task<Inbox> CreateUserInbox(CreateUserInboxCommand command)
        {
            Inbox newInbox = new Inbox()
            {
                UserId = command.UserId,
                Name = command.Name,
                Photo = command.Photo,
                ActTyp = command.ActTyp,
                CCtr = command.CCtr,
                InboxItems = new List<InboxItem>()
            };
            await _context.Inboxs.AddAsync(newInbox);
            await _context.SaveChangesAsync();
            return newInbox;
        }

        public async Task<Inbox> UpdateUserInbox(UpdateUserInboxCommand command)
        {
            Inbox myInbox = await _context.Inboxs.SingleAsync(i => i.UserId == command.UserId);
            myInbox.Name = command.Name;
            myInbox.Photo = command.Photo;
            myInbox.ActTyp = command.ActTyp;
            myInbox.CCtr = command.CCtr;
            await _context.SaveChangesAsync();
            return myInbox;
        }

        public async Task<bool> DeleteUserInbox(DeleteUserInboxCommand command)
        {
            var userInbox = await _context.Inboxs.SingleAsync(p => p.UserId == command.UserId);
            _context.Inboxs.Remove(userInbox);
            await _context.SaveChangesAsync();
            return true;
        }



        

        public async Task<double> SendData(CreateDataCommand command)
        {
            InboxItem inboxItem = await _context.InboxItems.SingleAsync(i => i.InboxItemId == command.InboxItemId);
            CreateCatsDto createCatsDto = new CreateCatsDto()
            {
                UserId = command.UserId,
                Name = command.Name,
                CatCreated = command.EntryDate,
                InboxItemId = command.InboxItemId,
                Client = inboxItem.Client,
                ProjectNumber = inboxItem.ProjectNumber,
                ProjectName = inboxItem.ProjectName,
                EntryDate = command.EntryDate,
                Hours = command.Hours   
            };
            CatsRecordResponse response = await _catsGrpcService.CreateCats(createCatsDto);

            CreateRaport createRaport = new CreateRaport
            (
                command.UserId,
                command.Name,
                command.JobId,
                command.InboxItemId,
                response.RecordHours,
                inboxItem.System,
                inboxItem.Ecm,
                inboxItem.Gpdm,
                inboxItem.ProjectNumber,
                inboxItem.Client,
                inboxItem.Status,
                command.Components,
                command.DrawingsComponents,
                command.DrawingsAssembly,
                inboxItem.DueDate,
                command.Started,
                command.Finished
            );
            await _publishEndpoint.Publish(createRaport);
            return response.RecordHours;
        }


        public async Task<double> DeleteData(DeleteDataCommand command)
        {
            InboxItem inboxItem = await _context.InboxItems.SingleAsync(i => i.InboxItemId == command.InboxItemId);
            DeleteCatsDto deleteCatsDto = new DeleteCatsDto()
            {
                InboxItemId = command.InboxItemId,
            };
            CatsRecordResponse response = await _catsGrpcService.DeleteCats(deleteCatsDto);
            if(response.RecordHours == 0)
            {
                DeleteRaport deleteRaport = new DeleteRaport
                (
                    command.InboxItemId
                );
                await _publishEndpoint.Publish(deleteRaport);
            }
            return response.RecordHours;
        }
    }
}
