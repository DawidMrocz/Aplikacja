namespace JobMicroservice.Entities
{
    public class UserJob
    {
        public int UserJobId { get; set; }
        public int? JobId { get; set; }
        public Job? Job { get; set; }
        public int? UserId { get; set; }
        public string? Name { get; set; }
        public string? Photo { get; set; }
    }
}
