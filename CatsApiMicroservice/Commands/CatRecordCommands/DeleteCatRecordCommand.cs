using CatsApiMicroservice.Repositories;
using MediatR;

namespace CatsApiMicroservice.Commands.CatRecordCommands
{
    public record DeleteCatRecordCommand : IRequest<bool>
    {
        public int CatRecordId { get; set; }
    }
    public class DeleteCatRecordCommandHandler : IRequestHandler<DeleteCatRecordCommand, bool>
    {
        private readonly IUserCatsRepository _userCatsRepository;

        public DeleteCatRecordCommandHandler(IUserCatsRepository userCatsRepository)
        {
            _userCatsRepository = userCatsRepository ?? throw new ArgumentNullException(nameof(userCatsRepository));
        }

        public async Task<bool> Handle(DeleteCatRecordCommand request, CancellationToken cancellationToken)
        {
            return await _userCatsRepository.DeleteCatRecord(request);
        }
    }
}