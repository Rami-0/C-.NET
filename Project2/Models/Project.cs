namespace Project2.Models
{
    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Priority Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CustomerCompanyId { get; set; } 
        public Company CustomerCompany { get; set; }
        public int ExecutorCompanyId { get; set; } 
        public Company ExecutorCompany { get; set; }
        public int ManagerId { get; set; } 
        public Employee Manager { get; set; }
        public ICollection<TaskProject> Tasks { get; set; } = new List<TaskProject>();
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }

}
