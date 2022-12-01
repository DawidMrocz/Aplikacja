namespace CatsApiMicroservice.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public string CCtr { get; set; }
        public string ActTyp { get; set; }
        public string Name { get; set; }
        public List<Cat> Cats { get; set; }
    }
}
