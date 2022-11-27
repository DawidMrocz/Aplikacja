namespace InboxMicroservice.Entities
{
    public class Inbox
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public List<InboxItem> InboxItems { get; set; }
    }
}
