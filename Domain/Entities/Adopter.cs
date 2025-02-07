﻿using Domain.Enums.Adopter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Adopter
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Adopter name is required")]
        [MaxLength(20, ErrorMessage = "Maximum legth for the Name is 20 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Adopter last name is required")]
        [MaxLength(20, ErrorMessage = "Maximum legth for the LastName is 20 characters")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Adopter email is required")]
        [MaxLength(100, ErrorMessage = "Maximum legth for the Email is 100 characters")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Adopter state is required")]
        [MaxLength(20)]
        public AdopterState State { get; set; }
    }
}
