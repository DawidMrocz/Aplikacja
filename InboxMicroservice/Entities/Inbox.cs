using System.ComponentModel.DataAnnotations;

namespace InboxMicroservice.Entities
{
    public class Inbox
    {
        public int InboxId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? CCtr { get; set; }
        public string? ActTyp { get; set; }
        public string Photo { get; set; }
        public List<InboxItem> InboxItems { get; set; }
    }
}
