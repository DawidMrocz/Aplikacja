using InboxMicroservice.Entities;
using InboxMicroservice.Models;
using JobMicroservice.Contracts;
using Microsoft.EntityFrameworkCore;
using UserMicroservice.Contracts;

namespace InboxMicroservice.Repositories
{
    public class InboxRepository : IInboxRepository
    {
        private readonly InboxDbContext _context;

        public InboxRepository(InboxDbContext context)
        {
            _context = context;
        }

        public async Task<List<Inbox>> GetInboxs()
        {
            return await _context.Inboxs.Include(i => i.InboxItems).AsNoTracking().ToListAsync();
        }

        public async Task<Inbox> GetMyInbox(int id)
        {
            return await _context.Inboxs.Include(i => i.InboxItems).AsNoTracking().SingleAsync(i => i.UserId == id);
        }

        public async Task CreateInboxItem(CreateInboxItem command)
        {
            var InboxUser = await _context.Inboxs.SingleAsync(u => u.UserId == command.UserId);
            InboxItem newInboxItem = new InboxItem()
            {
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
                SapText = command.SapText,
                Status = command.Status
            };
            await _context.InboxItems.AddAsync(newInboxItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInboxItem(UpdateInboxItem command)
        {
            var InboxItem = await _context.InboxItems.Where(i => i.JobId == command.JobId).ToListAsync();
            foreach(var item in InboxItem)
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
                item.SapText = command.SapText;
                item.Status = command.Status;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInboxItem(DeleteInboxItem command)
        {
            var productsToDelete = await _context.InboxItems.Where(p => p.Id == command.JobId).ToListAsync();
            _context.InboxItems.RemoveRange(productsToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task CreateUserInbox(CreateUserInbox command)
        {
            (int UserId, string Name, string Photo) = command;
            Inbox newInbox = new Inbox()
            {
                UserId = UserId,
                Name = Name,
                Photo = Photo,
                InboxItems = new List<InboxItem>()
            };
            await _context.Inboxs.AddAsync(newInbox);
            await _context.SaveChangesAsync();
        }

        public Task UpdateUserInbox(UpdateUserInbox command)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUserInbox(DeleteUserInbox command)
        {
            var userInbox = await _context.Inboxs.Where(p => p.UserId == command.UserId).SingleAsync();
            _context.Inboxs.Remove(userInbox);
            await _context.SaveChangesAsync();
        }

    }
}
