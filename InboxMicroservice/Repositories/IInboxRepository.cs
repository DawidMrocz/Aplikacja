﻿using InboxMicroservice.Commands.CatsCommands;
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
        public Task<InboxItem> CreateInboxItemFromJobs(CreateInboxItemFromJobCommand command);

        //CHANGES OF INBOX ITEM DUE TO CHANGE JOB
        public Task<bool> DeleteInboxItemFromJobs(DeleteInboxItemFromJobCommand command);
        public Task<List<InboxItem>> UpdateInboxItemFromJobs(UpdateInboxItemFromJobCommand command);

        //CHANGES OF JOB FROM INBOX
        public Task<bool> DeleteUserJobFromInbox(DeleteUserJobFromInboxCommand command);
        public Task<InboxItem> UpdateJobFromInbox(UpdateJobFromInboxCommand command);


        public Task<InboxItem> UpdateInboxItem(UpdateInboxItemCommand command);

        //CATS
        public Task<double> CreateData(CreateDataCommand command);
        public Task<double> UpdateData(UpdateDataCommand command);
        public Task<double> DeleteData(DeleteDataCommand command);

    }
}
