using CatsGrpcMicroservice.Protos;

namespace UserMicroservice.GrpcService
{
    public interface IUserGrpcService
    {
        public Task<CatsResponse> CreateUserCats(int UserId,string Name, string CCtr, string ActTyp);
        public Task<CatsResponse> UpdateUserCats(int UserId, string Name, string CCtr, string ActTyp);
        public Task<CatsResponse> DeleteUserCats(int UserId);
    }
}
