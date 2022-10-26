using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Api.Models
{
    [Table("Skills")]
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public IList<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
