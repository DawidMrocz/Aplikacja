namespace InboxMicroservice.Dtos
{
    public class UpdateCatsDto
    {
        public int UserId { get; set; }
        public int InboxItemId { get; set; }
        public double Hours { get; set; }
        public string EntryDate { get; set; }
    }
}
