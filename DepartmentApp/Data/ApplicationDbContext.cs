using DepartmentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartmentApp.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
