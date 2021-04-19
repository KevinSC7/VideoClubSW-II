﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoclubSWII.Models
{
    public class Compañia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre de la compañia")]
        public string Nombre { get; set; }
    }
}
