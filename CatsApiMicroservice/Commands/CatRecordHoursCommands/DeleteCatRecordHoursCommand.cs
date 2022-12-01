using CatsApiMicroservice.Repositories;
using MediatR;

namespace CatsApiMicroservice.Commands.CatRecordHoursCommands
{
    public record DeleteCatRecordHoursCommand : IRequest<bool>
    {
        public int CatRecordHoursId { get; set; }
    }
    public class DeleteCatRecordCommandHandler : IRequestHandler<DeleteCatRecordHoursCommand, bool>
    {
        private readonly IUserCatsRepository _userCatsRepository;

        public DeleteCatRecordCommandHandler(IUserCatsRepository userCatsRepository)
        {
            _userCatsRepository = userCatsRepository ?? throw new ArgumentNullException(nameof(userCatsRepository));
        }

        public async Task<bool> Handle(DeleteCatRecordHoursCommand request, CancellationToken cancellationToken)
        {
            return await _userCatsRepository.DeleteCatRecordHours(request);
        }
    }
}