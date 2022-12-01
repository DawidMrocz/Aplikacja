namespace InboxMicroservice.Dtos
{
    public class DeleteCatsDto
    {
        public int UserId { get; set; }
        public int InboxItemId { get; set; }
        public string EntryDate { get; set; }
    }
}
