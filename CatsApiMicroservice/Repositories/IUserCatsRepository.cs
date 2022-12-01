using CatsApiMicroservice.Entities;
using CatsApiMicroservice.Queries.EmployeeQueries;
using CatsApiMicroservice.Queries.CatQueries;
using CatsApiMicroservice.Commands.CatRecordCommands;
using CatsApiMicroservice.Commands.CatRecordHoursCommands;

namespace CatsApiMicroservice.Repositories
{
    public interface IUserCatsRepository
    {

        //Employees
        public Task<Employee> GetEmployee(GetEmployeeQuery query);


        //Cats
        public Task<Cat> GetCat(GetCatQuery query);


        //CatRecord
        public Task<bool> DeleteCatRecord(DeleteCatRecordCommand command);
        public Task<CatRecord> UpdateCatRecord(UpdateCatRecordCommand command);

        //CatRecordHours
        public Task<bool> DeleteCatRecordHours(DeleteCatRecordHoursCommand command);
        public Task<CatRecordHours> UpdateCatRecordHours(UpdateCatRecordHoursCommand command);
    }
}
