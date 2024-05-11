using MundrisoftAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace MundrisoftAssignment.Data

{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { set; get; }
        public DbSet<Department> department { set; get; }
        public DbSet<Users> users { set; get; }

    }
}
