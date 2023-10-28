using System.Collections.Generic;

namespace DAL.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Project> CustomerProjects { get; set; }
        public ICollection<Project> Projects { get; set; }
    }

}

