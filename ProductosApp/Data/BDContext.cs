using Microsoft.EntityFrameworkCore;
using ProductosApp.Models;

public class BDContext(DbContextOptions<BDContext> options) : DbContext(options)
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Producto> Productos { get; set; }
}
