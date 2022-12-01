namespace InboxMicroservice.Entities
{
    public class InboxItem
    {
        public int InboxItemId { get; set; }
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
        public string ProjectName { get; set; }
        public string Status { get; set; }
        public int Components { get; set; }
        public int DrawingsComponents { get; set; }
        public int DrawingsAssembly { get; set; }
        public string? WhenComplete { get; set; }
        public string Received { get; set; }
        public string? DueDate { get; set; }
        public string? Started { get; set; }
        public string? Finished { get; set; }
        public int? InboxId { get; set; }
        public Inbox? Inbox { get; set; }
    }
}
