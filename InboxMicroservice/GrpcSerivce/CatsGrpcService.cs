using CatsGrpcMicroservice.Protos;
using InboxMicroservice.Dtos;
using InboxMicroservice.Entities;
using InboxMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace InboxMicroservice.GrpcSerivce
{
    public class CatsGrpcService: ICatsGrpcService
    {
        private readonly CatsProtoService.CatsProtoServiceClient _catsProtoService;
        private readonly InboxDbContext _context;

        public CatsGrpcService(CatsProtoService.CatsProtoServiceClient catsProtoService, InboxDbContext context)
        {
            _catsProtoService = catsProtoService ?? throw new ArgumentNullException(nameof(catsProtoService));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<CatsRecordResponse> CreateCats(CreateCatsDto createCatsDto)
        {
            InboxItem inboxItem = await _context.InboxItems.SingleAsync(i => i.InboxItemId == createCatsDto.InboxItemId);
            CreateEmployeeRequest catsRequest = new CreateEmployeeRequest()
            {
                UserId = createCatsDto.UserId,
                Name = createCatsDto.Name,
                Cat = new CreateCatModel()
                {
                    CatCreated = createCatsDto.EntryDate,
                    CatRecord = new CreateCatRecordModel()
                    {
                        InboxItemId = inboxItem.InboxItemId,
                        Client = inboxItem.Client,
                        ProjectNumber = inboxItem.ProjectNumber,
                        ProjectName = inboxItem.ProjectName,
                        CatsRecordHours = new CreateCatsRecordHoursModel()
                        {
                            EntryDate = createCatsDto.EntryDate,
                            Hours = createCatsDto.Hours
                        }
                        
                    }
                }
                
            };
            return await _catsProtoService.CreateCatsAsync(catsRequest);
        }

        public async Task<CatsRecordResponse> DeleteCats(DeleteCatsDto deleteCatsDto)
        {
            DeleteEmployeeRequest catsRequest = new DeleteEmployeeRequest()
            {
                InboxItemId = deleteCatsDto.InboxItemId,
                UserId = deleteCatsDto.UserId,
                EntryDate = deleteCatsDto.EntryDate,
            };
            return await _catsProtoService.DeleteCatsAsync(catsRequest);
        }

    }
}
