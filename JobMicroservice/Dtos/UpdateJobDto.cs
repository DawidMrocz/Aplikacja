using JobMicroservice.Entities;

namespace JobMicroservice.Dtos
{
    public class UpdateJobDto
    {
        public string JobDescription { get; set; }
        public string Type { get; set; }
        public string System { get; set; }
        public string Link { get; set; }
        public string Engineer { get; set; }
        public int Ecm { get; set; }
        public int Gpdm { get; set; }
        public string ProjectNumber { get; set; }
        public string Client { get; set; }
        public string SapText { get; set; }
        public string Status { get; set; }
        public DateTime Received { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Finished { get; set; }
    }
}
