
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskProject> TaskProjects { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasOne(p => p.CustomerCompany)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CustomerCompanyId)
                .OnDelete(DeleteBehavior.Restrict); 

       
            modelBuilder.Entity<Project>()
                .HasOne(p => p.ExecutorCompany)
                .WithMany()
                .HasForeignKey(p => p.ExecutorCompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Manager)
                .WithMany()
                .HasForeignKey(p => p.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

         
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Company)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Entities.TaskProject>()
    .HasOne(t => t.Author)
    .WithMany(e => e.CreatedTasks)
    .HasForeignKey(t => t.AuthorId);

            modelBuilder.Entity<Entities.TaskProject>()
     .HasOne(t => t.Executor)
     .WithMany()
     .HasForeignKey(t => t.ExecutorId)
     .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
