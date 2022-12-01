using InboxMicroservice.Commands.CatsCommands;
using InboxMicroservice.Commands.InboxCommands;
using InboxMicroservice.Commands.InboxItemCommands;
using InboxMicroservice.Entities;
using InboxMicroservice.Queries;

namespace InboxMicroservice.Repositories
{
    public interface IInboxRepository
    {
        //GET USER IBOX
        public Task<Inbox> GetMyInbox(GetMyInboxQuery query);

        //CHANGES OF USER INBOX DUE TO CHANGES OF USER
        public Task<Inbox> CreateUserInbox(CreateUserInboxCommand command);
        public Task<bool> DeleteUserInbox(DeleteUserInboxCommand command);
        public Task<Inbox> UpdateUserInbox(UpdateUserInboxCommand command);

        //ADD TO USER INBOX
        public Task<InboxItem> CreateInboxItem(CreateInboxItemCommand command);

        //CHANGES OF INBOX ITEM DUE TO CHANGE JOB
        public Task<bool> DeleteInboxItem(DeleteInboxItemCommand command);
        public Task<List<InboxItem>> UpdateInboxItem(UpdateInboxItemCommand command);

        //CHANGES OF JOB FROM INBOX
        public Task<bool> DeleteInboxItemFromInbox(DeleteInboxItemFromInboxCommand command);
        public Task<InboxItem> UpdateInboxItemFromInbox(UpdateInboxItemFromInboxCommand command);


        //CATS & REPORTS OPTIONS
        public Task<bool> CreateData(CreateDataCommand command);
        public Task<bool> UpdateData(UpdateDataCommand command);
        public Task<bool> DeleteData(DeleteDataCommand command);

    }
}
