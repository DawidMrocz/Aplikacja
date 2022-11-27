namespace InboxMicroservice.Entities
{
    public class InboxItem
    {
        public int Id { get; set; }
        public string JobDescription { get; set; }
        public int JobId { get; set; }
        public string Type { get; set; }
        public string System { get; set; }
        public string Link { get; set; }
        public string Engineer { get; set; }
        public int Ecm { get; set; }
        public int Hours { get; set; }
        public int Gpdm { get; set; }
        public string ProjectNumber { get; set; }
        public string Client { get; set; }
        public string SapText { get; set; }
        public string Status { get; set; }
        public int Components { get; set; }
        public int DrawingsComponents { get; set; }
        public int DrawingsAssembly { get; set; }
        public DateTime? WhenComplete { get; set; }
        public DateTime Received { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Finished { get; set; }
        public int? InboxId { get; set; }
        public Inbox? Inbox { get; set; }
    }
}
