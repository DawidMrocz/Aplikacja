namespace RaportsMicroservice.Dtos
{
    public class UpdateDto
    {
        public int UserRecordId { get; set; }
        public double TaskHours { get; set; }
        public string System { get; set; }
        public int Ecm { get; set; }
        public int Gpdm { get; set; }
        public string ProjectNumber { get; set; }
        public int Components { get; set; }
        public int DrawingOfComponent { get; set; }
        public int DrawingOfAssemblies { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public string Client { get; set; }
    }
}