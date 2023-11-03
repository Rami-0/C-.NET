using DAL.DatabaseContext;
using DAL.Repositories;
using BLL.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(connectionString));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "company_employees",
        pattern: "Company/Employees/{id?}",
        defaults: new { controller = "Company", action = "Employees" }
    );

    endpoints.MapControllerRoute(
        name: "company_add_employee",
        pattern: "Company/AddEmployee/{companyId?}",
        defaults: new { controller = "Company", action = "AddEmployee" }
    );

    endpoints.MapControllerRoute(
        name: "company_remove_employee",
        pattern: "Company/RemoveEmployee/{companyId?}",
        defaults: new { controller = "Company", action = "RemoveEmployee" }
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

