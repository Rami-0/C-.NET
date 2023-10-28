using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public int CustomerCompanyId { get; set; }
        public Company CustomerCompany { get; set; }
        public int ExecutorCompanyId { get; set; }
        public Company ExecutorCompany { get; set; }
        public int ManagerId { get; set; }
        public Employee Manager { get; set; }
        public ICollection<TaskProject> Tasks { get; set; }
    }


}

