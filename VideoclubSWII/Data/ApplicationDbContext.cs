using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoclubSWII.Models;

namespace VideoclubSWII.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Alquiler> Alquileres { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CategoriaPelicula> RelacionesCategoriaPelicula { get; set; }
        public DbSet<Compañia> Compañias { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
    }
}
