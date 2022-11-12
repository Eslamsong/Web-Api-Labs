using Authentication.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Data.Context
{
    public class EmployeeContext :IdentityDbContext<Employee> //Extending the Users
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Employee>().ToTable("Employees"); //change the table name
        }
    }
}
