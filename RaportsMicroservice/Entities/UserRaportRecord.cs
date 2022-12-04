namespace RaportsMicroservice.Entities
{
    public class UserRaportRecord
    {
        public int UserRaportRecordId { get; set; }
        public int UserRaportId { get; set; }
        public UserRaport UserRaport { get; set; }
        public int InboxItemId { get; set; }
        public int JobId { get; set; }
        public string System { get; set; }
        public int Ecm { get; set; }
        public int Gpdm { get; set; }
        public string ProjectNumber { get; set; }
        public string Client { get; set; }
        public int Components { get; set; }
        public int DrawingsOfComponents { get; set; }
        public int DrawingsOfAssemblies { get; set; }
        public double TaskHours { get; set; }
        public string? DueDate { get; set; }
        public string? Started { get; set; }
        public string? Finished { get; set; }
    }
}
