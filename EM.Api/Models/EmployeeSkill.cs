﻿using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Api.Models
{
    [Table("EmployeeSkills")]
    public class EmployeeSkill
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
