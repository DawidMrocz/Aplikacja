using JobMicroservice.Commands;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using JobMicroservice.Entities;
using JobMicroservice.Models;
using JobMicroservice.Contracts;
using JobMicroservice.Extensions;
using JobMicroservice.Queries;

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
                itemToAdd.SapText,
                itemToAdd.Status
                );
            
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
                Status = command.Status,
                Client = command.Client,
                SapText = command.SapText,
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

        public async Task<Job> UpdateJob(UpdateJobCommand updatedJob, int id)
        {
            var currentTask = await _context.Jobs.SingleAsync(r => r.JobId == id);

            currentTask.JobDescription = updatedJob.JobDescription;
            currentTask.Type = updatedJob.Type;
            currentTask.System = updatedJob.System;
            currentTask.ProjectNumber = updatedJob.ProjectNumber;
            currentTask.Link = updatedJob.Link;
            currentTask.Engineer = updatedJob.Engineer;
            currentTask.Ecm = updatedJob.Ecm;
            currentTask.Gpdm = updatedJob.Gpdm;
            currentTask.Status = updatedJob.Status;
            currentTask.Client = updatedJob.Client;
            currentTask.SapText = updatedJob.SapText;

            _context.SaveChanges();
            return currentTask;
        }

        public async Task<Job> UpdateJob(UpdateJobCommand command)
        {
            var currentTask = await _context.Jobs.SingleAsync(r => r.JobId == command.JobId);

            currentTask.JobDescription = command.JobDescription;
            currentTask.Type = command.Type;
            currentTask.System = command.System;
            currentTask.ProjectNumber = command.ProjectNumber;
            currentTask.Link = command.Link;
            currentTask.Engineer = command.Engineer;
            currentTask.Ecm = command.Ecm;
            currentTask.Gpdm = command.Gpdm;
            currentTask.Status = command.Status;
            currentTask.Client = command.Client;
            currentTask.SapText = command.SapText;

            _context.SaveChanges();
            return currentTask;
        }
    }
}


