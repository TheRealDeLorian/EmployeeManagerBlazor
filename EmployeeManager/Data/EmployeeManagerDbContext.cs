using Microsoft.EntityFrameworkCore;
using EmployeeManager.Data.Models;

namespace EmployeeManager.Data
{
    public class EmployeeManagerDbContext : DbContext
    {

        public EmployeeManagerDbContext(
            DbContextOptions<EmployeeManagerDbContext> options) : base(options) { }
        
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Finance" },
                new Department { Id = 2, Name = "Sales" });

            modelBuilder.Entity<Employee>().HasData(
               new Employee { Id = 1, FirstName = "Anna",LastName="Rockstar",DepartmentId=2 },
               new Employee { Id = 2, FirstName = "Julia",LastName="Developer",DepartmentId=1,IsDeveloper = true });
        }

    }
}
