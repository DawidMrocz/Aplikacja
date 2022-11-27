namespace JobMicroservice.Entities
{
    public class UserJob
    {
        public int Id { get; set; }
        public List<Job>? Jobs { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
    }
}
