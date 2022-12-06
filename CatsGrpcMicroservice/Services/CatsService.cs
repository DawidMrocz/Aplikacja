using Grpc.Core;
using CatsGrpcMicroservice.Commands;
using MediatR;
using CatsGrpcMicroservice.Protos;

namespace CatsGrpcMicroservice.Services
{
    public class CatsService : CatsProtoService.CatsProtoServiceBase
    {
        private readonly IMediator _mediator;

        public CatsService(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public override async Task<CatsRecordResponse> CreateCats(CreateEmployeeRequest request, ServerCallContext context)
        {
            CreateCatsCommand createCatsCommand = new CreateCatsCommand()
            {
                UserId = request.UserId,
                Name = request.Name,
                CatCreated = request.Cat.CatCreated,
                InboxItemId = request.Cat.CatRecord.InboxItemId,
                ProjectNumber=request.Cat.CatRecord.ProjectNumber,
                ProjectName = request.Cat.CatRecord.ProjectName,
                Client = request.Cat.CatRecord.Client,
                EntryDate = request.Cat.CatRecord.CatsRecordHours.EntryDate,
                Hours = request.Cat.CatRecord.CatsRecordHours.Hours,
            };
            double hours = await _mediator.Send(createCatsCommand);
            return new CatsRecordResponse() { Success = true,RecordHours = hours };
        }


        public override async Task<CatsRecordResponse> DeleteCats(DeleteEmployeeRequest request, ServerCallContext context)
        {
            DeleteCatsCommand deleteCatsCommand = new DeleteCatsCommand()
            {
                InboxItemId = request.InboxItemId,
                EntryDate = request.EntryDate,
            };
            double hours = await _mediator.Send(deleteCatsCommand);
            return new CatsRecordResponse() { Success = true, RecordHours = hours };
        }





        public override async Task<CatsResponse> CreateUserCats(CreateCatsRequest request, ServerCallContext context)
        {
            CreateEmployeeCommand createEmployeeCommand = new CreateEmployeeCommand()
            {
                UserId = request.UserId,
                Name = request.Name,
                CCtr = request.CCtr,
                ActTyp = request.ActTyp,
            };
            await _mediator.Send(createEmployeeCommand);
            return new CatsResponse() { Success = true };
        }
        public override async Task<CatsResponse> UpdateUserCats(UpdateCatsRequest request, ServerCallContext context)
        {
            UpdateEmployeeCommand updateEmployeeCommand = new UpdateEmployeeCommand()
            {
                UserId = request.UserId,
                Name = request.Name,
                CCtr = request.CCtr,
                ActTyp = request.ActTyp,
            };
            await _mediator.Send(updateEmployeeCommand);
            return new CatsResponse() { Success = true };
        }
        public override async Task<CatsResponse> DeleteUserCats(DeleteCatsRequest request, ServerCallContext context)
        {
            DeleteEmployeeCommand deleteEmployeeCommand = new DeleteEmployeeCommand()
            {
                UserId = request.UserId,
            };
            await _mediator.Send(deleteEmployeeCommand);
            return new CatsResponse() { Success = true };
        }
    }
}