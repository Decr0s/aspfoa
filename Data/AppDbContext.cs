using Microsoft.EntityFrameworkCore;
using avd4.Models;

namespace avd4.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {   }

        public DbSet<Produto> Produtos {get; set;}
        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<Pedido> Pedidos {get; set;}
        public DbSet<Entrega> Entregas {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pedido>()
                .HasKey(x => new { x.ClienteId, x.ProdutoId });


            modelBuilder.Entity<Pedido>()
                .HasKey(x => x.Id)
                .HasName("PrimaryKey_Id");
        }
    }
}