using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EM.Shared.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime? BirtDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        public string Department { get; set; }

        [Required]
        public int? DepartmentId { get; set; }

        public List<SkillDto> Skills { get; set; }
    }
}
