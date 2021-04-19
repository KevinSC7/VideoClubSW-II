﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VideoclubSWII.Models
{
    public class CategoriaPelicula
    {
        [Key]
        public int Id { get; set; }

        public Pelicula pelicula { get; set; }

        public Categoria categoria { get; set; }
    }
}
