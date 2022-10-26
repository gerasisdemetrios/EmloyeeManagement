﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EM.Shared.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
