
using RaportMicroservice.Queries;
using RaportsMicroservice.Commands.RaportCommands;
using RaportsMicroservice.Commands.RaportDueToJobCommands;
using RaportsMicroservice.Entities;
using RaportsMicroservice.Queries;

namespace RaportsMicroservice.Repositories
{
    public interface IRaportRepository
    {
        

        public Task<Raport> GetRaport(GetRaportQuery query);
        public Task<List<Raport>> GetRaports(GetRaportsQuery query);

        public Task<UserRaport> CreateRaport(CreateRaportCommand command);
        public Task<UserRaportRecord> UpdateRaport(UpdateRaportCommand command);
        public Task<bool> DeleteRaport(DeleteRaportCommand command);

        public Task<bool> UpdateRaportDueToJob(UpdateRaportDueToJobCommand command);
        public Task<bool> DeleteRaportDueToJob(DeleteRaportDueToJobCommand command);

    }
}
