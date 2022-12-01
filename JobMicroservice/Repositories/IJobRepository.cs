using JobMicroservice.Commands;
using JobMicroservice.Contracts;
using JobMicroservice.Entities;
using JobMicroservice.Queries;

namespace JobMicroservice.Repositories
{
    public interface IJobRepository
    {
        public Task<List<Job>> GetJobs();
        public Task<Job> GetJob(GetJobQuery command);

        public Task<bool> CreateInboxItem(CreateInboxItemCommand command);
        public Task<bool> CreateInboxItemForSomeone();

        public Task<Job> CreateJob(CreateJobCommand command);
        public Task<bool> DeleteJob(DeleteJobCommand command);
        public Task<Job> UpdateJob(UpdateJobCommand command);


        public Task<Job> DeleteUserJobFormInbox(DeleteJobFromInboxCommand command);
        public Task<Job> UpdateJobFromInbox(UpdateJobFromInboxCommand command);
    }
}
