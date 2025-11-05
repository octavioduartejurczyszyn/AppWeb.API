using Microsoft.EntityFrameworkCore;
using AppWeb.API.Models;

namespace AppWeb.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Estas propiedades representan las tablas
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }
    }
}
        /*Qué hace esto:

        -Define una clase que representa tu base de datos.

        -Cada DbSet<T> es una tabla (EF la crea si no existe).

        -EF usa las propiedades de las clases de Models como columnas.*/

