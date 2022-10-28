using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Api.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? BirtDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public DateTime CreatedAt { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public virtual Department Dapartment { get; set; }
        public virtual List<EmployeeSkill> EmployeeSkills { get; set; } = new();
    }
}
