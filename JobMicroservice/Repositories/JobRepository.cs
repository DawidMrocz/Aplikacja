using JobMicroservice.Commands;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using JobMicroservice.Entities;
using JobMicroservice.Models;
using JobMicroservice.Extensions;
using JobMicroservice.Queries;
using JobMicroservice.Contracts.InboxItemContracts;

namespace JobMicroservice.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly JobDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IDistributedCache _cache;
        public JobRepository(JobDbContext context, IDistributedCache cache, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _cache = cache;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<List<Job>> GetJobs()
        {
            return await _context.Jobs.ToListAsync();
        }
        public async Task<bool> CreateInboxItem(CreateInboxItemCommand command)
        {
            var itemToAdd = await _context.Jobs.SingleAsync(j => j.JobId == command.JobId);
            CreateInboxItem item = new CreateInboxItem(
                command.UserId,
                itemToAdd.JobId,
                itemToAdd.JobDescription,
                itemToAdd.Type,
                itemToAdd.System,
                itemToAdd.Link,
                itemToAdd.Engineer,
                itemToAdd.Ecm,
                itemToAdd.Gpdm,
                itemToAdd.ProjectNumber,
                itemToAdd.Client,
                itemToAdd.ProjectName,
                itemToAdd.Status,
                itemToAdd.DueDate,
                itemToAdd.Received
                );
            UserJob userJob = new UserJob()
            {
                UserId = command.UserId,
                JobId = itemToAdd.JobId,
                Name = command.Name,
                Photo = command.Photo
            };
            await _context.UserJobs.AddAsync(userJob);
            await _context.SaveChangesAsync();
            await _publishEndpoint.Publish(item);
            return true;
        }

        public async Task<Job> GetJob(GetJobQuery command)
        {
            return await _context.Jobs.SingleAsync(r => r.JobId == command.JobId);
        }

        public async Task<Job> CreateJob(CreateJobCommand command)
        {

        var newJob = new Job()
            { 
                JobDescription = command.JobDescription,
                Type = command.Type,
                System = command.System,
                ProjectNumber = command.ProjectNumber,
                Link = command.Link,
                Engineer = command.Engineer,
                Ecm = command.Ecm,
                Gpdm = command.Gpdm,
                Received = command.Received,
                DueDate = command.DueDate,
                Status = command.Status,
                Client = command.Client,
                ProjectName = command.ProjectName,
            };
            await _context.Jobs.AddAsync(newJob);
            await _context.SaveChangesAsync();
            return newJob;
        }

        public async Task<bool> DeleteJob(DeleteJobCommand command)
        {
            var TaskToDelete = await _context.Jobs.SingleAsync(r => r.JobId == command.JobId);
            await _cache.DeleteRecordAsync<Task>($"Profile_{command.JobId}");
            await _publishEndpoint.Publish(new DeleteInboxItem(command.JobId));
            _context.Remove(TaskToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Job> UpdateJob(UpdateJobCommand updatedJob)
        {
            var currentTask = await _context.Jobs.SingleAsync(r => r.JobId == updatedJob.JobId);

            currentTask.JobDescription = updatedJob.JobDescription;
            currentTask.Type = updatedJob.Type;
            currentTask.System = updatedJob.System;
            currentTask.ProjectNumber = updatedJob.ProjectNumber;
            currentTask.Link = updatedJob.Link;
            currentTask.Engineer = updatedJob.Engineer;
            currentTask.Received = updatedJob.Received;
            currentTask.Ecm = updatedJob.Ecm;
            currentTask.Gpdm = updatedJob.Gpdm;
            currentTask.Client = updatedJob.Client;
            currentTask.DueDate = updatedJob.DueDate;

            _context.SaveChanges();
            return currentTask;
        }

        public async Task<UserJob> DeleteUserJobFormInbox(DeleteUserJobFromInboxCommand command)
        {
            UserJob userJob = await _context.UserJobs.SingleAsync(r => r.JobId == command.JobId && r.UserId == command.UserId);
            _context.UserJobs.Remove(userJob);
            _context.SaveChanges();
            return userJob;
        }

        public async Task<Job> UpdateJobFromInbox(UpdateJobFromInboxCommand command)
        {
            var currentTask = await _context.Jobs.SingleAsync(r => r.JobId == command.JobId);

            currentTask.Status = command.Status;
            currentTask.Started = command.Started;
            currentTask.Finished = command.Finished;
            currentTask.WhenComplete = command.WhenComplete;

            _context.SaveChanges();
            return currentTask;
        }

        public Task<bool> CreateInboxItemForSomeone()
        {
            throw new NotImplementedException();
        }
    }
}


