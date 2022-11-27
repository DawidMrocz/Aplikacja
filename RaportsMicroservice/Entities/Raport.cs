namespace RaportsMicroservice.Entities
{
    public class Raport
    {
        public int RaportId { get; set; }
        public double TotalHours { get; set; }
        public List<UserRaport> UserRaports { get; set; }
        public string? Created { get; set; }
    }
}
