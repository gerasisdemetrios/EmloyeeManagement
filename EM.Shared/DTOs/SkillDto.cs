using System;
using System.ComponentModel.DataAnnotations;

namespace EM.Shared.DTOs
{
    public class SkillDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
