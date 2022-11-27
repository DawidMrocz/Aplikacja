using InboxMicroservice.Entities;
using JobMicroservice.Contracts;
using UserMicroservice.Contracts;

namespace InboxMicroservice.Repositories
{
    public interface IInboxRepository
    {
        public Task<Inbox> GetMyInbox(int UserId);
        public Task<List<Inbox>> GetInboxs();

        public Task CreateUserInbox(CreateUserInbox command);
        public Task DeleteUserInbox(DeleteUserInbox command);
        public Task UpdateUserInbox(UpdateUserInbox command);

        public Task CreateInboxItem(CreateInboxItem command);
        public Task DeleteInboxItem(DeleteInboxItem command);
        public Task UpdateInboxItem(UpdateInboxItem command);
        
    }
}
