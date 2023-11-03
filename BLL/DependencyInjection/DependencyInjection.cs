/*using BLL.Services;
using DAL.DatabaseContext;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



namespace BLL.DependencyInjection
{
    public class DependencyInjection

    {
        private readonly object WebApplication;

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.configuration.GetConnectionString("DefaultConnection");
            builder.services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            builder.services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.services.AddTransient<IEmployeeService, EmployeeService>();
            builder.services.AddTransient<IProjectService, ProjectService>();
            builder.services.AddTransient<ITaskService, TaskService>();
            builder.services.AddTransient<ICompanyService, CompanyService>();
            builder.services.AddControllersWithViews();
            // Other service configurations go here.
        }
    }
}*/