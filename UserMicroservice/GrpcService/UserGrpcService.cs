using CatsGrpcMicroservice.Protos;

namespace UserMicroservice.GrpcService
{
    public class UserGrpcService : IUserGrpcService
    {
        private readonly CatsProtoService.CatsProtoServiceClient _catsProtoService;

        public UserGrpcService(CatsProtoService.CatsProtoServiceClient catsProtoService)
        {
            _catsProtoService = catsProtoService ?? throw new ArgumentNullException(nameof(catsProtoService));
        }

        public async Task<CatsResponse> CreateUserCats(int UserId, string Name, string CCtr, string ActTyp)
        {
            CreateCatsRequest userCatsRequest = new CreateCatsRequest()
            {
                UserId = UserId,
                Name = Name,
                CCtr = CCtr,
                ActTyp = ActTyp,
            };
            return await _catsProtoService.CreateUserCatsAsync(userCatsRequest);
        }

        public async Task<CatsResponse> DeleteUserCats(int UserId)
        {
            DeleteCatsRequest userCatsRequest = new DeleteCatsRequest()
            {
                UserId = UserId,
            };
            return await _catsProtoService.DeleteUserCatsAsync(userCatsRequest);
        }

        public async Task<CatsResponse> UpdateUserCats(int UserId, string Name,string CCtr,string ActTyp)
        {
            UpdateCatsRequest userCatsRequest = new UpdateCatsRequest()
            {
                UserId = UserId,
                Name = Name,
                CCtr = CCtr,
                ActTyp = ActTyp,

            };
            return await _catsProtoService.UpdateUserCatsAsync(userCatsRequest);
        }
    }
}
