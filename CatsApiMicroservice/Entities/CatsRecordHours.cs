namespace CatsApiMicroservice.Entities
{
    public class CatRecordHours
    {
        public int CatRecordHoursId { get; set; }
        public string Date { get; set; }
        public double Hours { get; set; }
        public int CatRecordId { get; set; }
        public CatRecord CatRecord { get; set; }
    }
}
