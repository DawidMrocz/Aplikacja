namespace RaportsMicroservice.Entities
{
    public class UserRaportRecord
    {
        public int UserRaportRecordId { get; set; }
        public int UserRaportId { get; set; }
        public UserRaport UserRaport { get; set; }
        public int InboxId { get; set; }
        public string System { get; set; }
        public int Ecm { get; set; }
        public int Gpdm { get; set; }
        public string ProjectNumber { get; set; }
        public string Client { get; set; }
        public int Components { get; set; }
        public int DrawingsOfComponents { get; set; }
        public int DrawingsOfAssemblies { get; set; }
        public double TaskHours { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Finished { get; set; }
    }
}
