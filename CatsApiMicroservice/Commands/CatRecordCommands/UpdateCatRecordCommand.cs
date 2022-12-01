using CatsApiMicroservice.Entities;
using CatsApiMicroservice.Repositories;
using MediatR;

namespace CatsApiMicroservice.Commands.CatRecordCommands
{
    public record UpdateCatRecordCommand : IRequest<CatRecord>
    {
        public int CatRecordId { get; set; }
        public string Receiver { get; set; }
        public string SapText { get; set; }
    }
    public class UpdateCatRecordCommandHandler : IRequestHandler<UpdateCatRecordCommand, CatRecord>
    {
        private readonly IUserCatsRepository _userCatsRepository;

        public UpdateCatRecordCommandHandler(IUserCatsRepository userCatsRepository)
        {
            _userCatsRepository = userCatsRepository ?? throw new ArgumentNullException(nameof(userCatsRepository));
        }

        public async Task<CatRecord> Handle(UpdateCatRecordCommand request, CancellationToken cancellationToken)
        {
            return await _userCatsRepository.UpdateCatRecord(request);
        }
    }
}