namespace CatsGrpcMicroservice.Entities
{
    public class CatRecord
    {
        public int CatRecordId { get; set; }
        public int InboxItemId { get; set; }
        public string Receiver { get; set; }
        public string SapText { get; set; }


        public int CatId { get; set; }
        public Cat Cat { get; set; }
        public List<CatRecordHours> CatRecordHours { get; set; }
    }
}
