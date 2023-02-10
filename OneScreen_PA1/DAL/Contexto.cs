using Microsoft.EntityFrameworkCore;
using PantallaOne.Models;

#nullable disable 

namespace PantallaOne.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Articulos> Articulo { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public DbSet<Suplidor> Suplidor { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria>().HasData(

            new Categoria { CategoriaId = 1, Descripcion = "Bebidas" },
            new Categoria { CategoriaId = 2, Descripcion = "Frutas" },       // Categorias de los articulos
            new Categoria { CategoriaId = 3, Descripcion = "Lacteos" },
            new Categoria { CategoriaId = 4, Descripcion = "Vegetales" },
            new Categoria { CategoriaId = 5, Descripcion = "Carnes" }
            );

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pago>().HasData(

            new Pago { PagoId = 1, Metodo = "Deposito" },
            new Pago { PagoId = 2, Metodo = "Efectivo" },             // Metodos de pago
            new Pago { PagoId = 3, Metodo = "Tarjeta de credito" }

            );
        }
    }
}