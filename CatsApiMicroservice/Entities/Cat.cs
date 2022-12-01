namespace CatsApiMicroservice.Entities
{
    public class Cat
    {
        public int CatId { get; set; }
        public string CatCreated { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public List<CatRecord> CatRecords { get; set; }
    }
}
