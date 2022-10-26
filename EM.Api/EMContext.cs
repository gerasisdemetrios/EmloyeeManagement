using EM.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EM.Api
{
    public class EMContext : DbContext
    {
        public EMContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeSkill>().HasKey(x => new { x.EmployeeId, x.SkillId });
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
