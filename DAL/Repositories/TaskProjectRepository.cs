using DAL.DatabaseContext;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TaskProjectRepository : GenericRepository<TaskProject>, ITaskProjectRepository
    {
        public TaskProjectRepository(AppDbContext context) : base(context)
        {
        }
    }
}
