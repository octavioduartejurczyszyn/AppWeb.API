using AppWeb.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWeb.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ======================================
            // RELACIÓN: Articulo -> Marca (FK: IdMarca)
            // ======================================
            modelBuilder.Entity<Articulo>()
                .HasOne<Marca>()                // Un artículo tiene una marca
                .WithMany()                     // Una marca tiene muchos artículos (sin navigation property)
                .HasForeignKey(a => a.IdMarca)  // Clave foránea en Articulo
                .OnDelete(DeleteBehavior.Restrict);

            // ======================================
            // RELACIÓN: Articulo -> Categoria (FK: IdCategoria)
            // ======================================
            modelBuilder.Entity<Articulo>()
                .HasOne<Categoria>()                // Un artículo tiene una categoría
                .WithMany()                         // Una categoría tiene muchos artículos
                .HasForeignKey(a => a.IdCategoria)  // Clave foránea en Articulo
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
