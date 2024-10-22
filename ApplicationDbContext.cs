using Microsoft.EntityFrameworkCore;
using SecurityOffice.Models;

namespace SecurityOffice
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAttendance> EmployeesAttendances { get; set; }
    }
}
