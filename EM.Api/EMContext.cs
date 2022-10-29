using EM.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;

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

            modelBuilder.Entity<EmployeeSkill>()
                    .HasOne(bc => bc.Skill)
                    .WithMany(b => b.EmployeeSkills)
                    .HasForeignKey(bc => bc.SkillId);

            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(bc => bc.Employee)
                .WithMany(c => c.EmployeeSkills)
                .HasForeignKey(bc => bc.EmployeeId);

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Development", CreatedAt = DateTime.Now, Description = "This the Development team" },
                new Department { Id = 2, Name = "Consulting", CreatedAt = DateTime.Now, Description = "This the Consulting team" },
                new Department { Id = 3, Name = "Back Office", CreatedAt = DateTime.Now, Description = "This the Back Office team" }
                );

            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "Communication", CreatedAt = DateTime.Now, Description = "Ability to communicate" },
                new Skill { Id = 2, Name = "Teamwork", CreatedAt = DateTime.Now, Description = "Ability to work with team" },
                new Skill { Id = 3, Name = "Problem solving", CreatedAt = DateTime.Now, Description = "Ability to solve problems" }
                );
        }


        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
