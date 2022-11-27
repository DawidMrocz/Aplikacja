namespace RaportsMicroservice.Entities
{
    public class UserRaport
    {
        public int UserRaportId { get; set; }
        public int RaportId { get; set; }
        public Raport Raport { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public double UserAllHours { get; set; }
        public List<UserRaportRecord> UserRaportRecords { get; set; }
    }
}
