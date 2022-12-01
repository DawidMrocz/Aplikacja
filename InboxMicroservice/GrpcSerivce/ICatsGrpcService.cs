using CatsGrpcMicroservice.Protos;
using InboxMicroservice.Dtos;

namespace InboxMicroservice.GrpcSerivce
{
    public interface ICatsGrpcService
    {
        public Task<CatsRecordResponse> CreateCats(CreateCatsDto createCatsDto);
        public Task<CatsRecordResponse> UpdateCats(UpdateCatsDto updateCatsDto);
        public Task<CatsRecordResponse> DeleteCats(DeleteCatsDto deleteCatsDto);
    }
}
