using Microsoft.EntityFrameworkCore;

namespace MVCD2.Models
{
    public class MVCITIDbContext : DbContext
    {

        public MVCITIDbContext()
        {

        }
        public MVCITIDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-J7MPLTV\\SS17;Initial Catalog= MVCITI;Integrated Security=True;TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentLocation>().HasKey("DeptNumber", "Location");
            modelBuilder.Entity<WorksOnProject>().HasKey("ESSN", "projectNum");

            modelBuilder.Entity<Employee>().HasOne(s => s.SuperVisor).WithMany(e => e.Employees);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<DepartmentLocation> DepartmentLocation { get; set; }
        public DbSet<WorksOnProject> WorksOnProjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Dependent> Dependents{ get; set; }
    }
}
