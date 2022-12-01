using CatsApiMicroservice.Entities;
using CatsApiMicroservice.Repositories;
using MediatR;

namespace CatsApiMicroservice.Commands.CatRecordHoursCommands
{ 
    public record UpdateCatRecordHoursCommand : IRequest<CatRecordHours>
    {
        public int CatRecordId { get; set; }
        public string CCtr { get; set; }
        public string ActTyp { get; set; }
        public string Receiver { get; set; }
        public string SapText { get; set; }
    }
    public class UpdateCatRecordHoursCommandHandler : IRequestHandler<UpdateCatRecordHoursCommand, CatRecordHours>
    {
        private readonly IUserCatsRepository _userCatsRepository;

        public UpdateCatRecordHoursCommandHandler(IUserCatsRepository userCatsRepository)
        {
            _userCatsRepository = userCatsRepository ?? throw new ArgumentNullException(nameof(userCatsRepository));
        }

        public async Task<CatRecordHours> Handle(UpdateCatRecordHoursCommand request, CancellationToken cancellationToken)
        {
            return await _userCatsRepository.UpdateCatRecordHours(request);
        }
    }
}