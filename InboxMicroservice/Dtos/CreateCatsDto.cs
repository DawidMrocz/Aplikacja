using InboxMicroservice.Dtos;
using MassTransit.SagaStateMachine;

namespace InboxMicroservice.Dtos
{
    public class CreateCatsDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int InboxItemId { get; set; }
        public double Hours { get; set; }
        public string EntryDate { get; set; }
        public string CatCreated { get; set; }
        public string Client { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
    }
}
