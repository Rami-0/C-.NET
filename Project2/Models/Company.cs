namespace Project2.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Project> Projects { get; set; } = new List<Project>();
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}

