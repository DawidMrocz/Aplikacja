
using RaportMicroservice.Queries;
using RaportsMicroservice.Commands.UserRaportCommands;
using RaportsMicroservice.Commands.UserRaportRecordCommands;
using RaportsMicroservice.Entities;
using RaportsMicroservice.Queries;

namespace RaportsMicroservice.Repositories
{
    public interface IRaportRepository
    {
        

        public Task<Raport> GetRaport(GetRaportQuery query);
        public Task<List<Raport>> GetRaports(GetRaportsQuery query);


        public Task<UserRaport> UpdateUserRaport(UpdateUserRaportCommand command);


        public Task<UserRaport> AddUserRaportRecord(AddUserRaportRecordCommand command);
        public Task<UserRaportRecord> UpdateUserRaportRecord(UpdateUserRaportRecordCommand command);
        public Task<bool> DeleteUserRaportRecord(DeleteUserRaportRecordCommand command);
    }
}
