using System.Collections.Generic;

namespace DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public ICollection<TaskProject> CreatedTasks { get; set; }
        public ICollection<TaskProject> AssignedTasks { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }

}

