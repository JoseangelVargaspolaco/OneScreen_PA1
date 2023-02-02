using Microsoft.EntityFrameworkCore;
using PantallaOne.Models;

#nullable disable 

namespace PantallaOne.DAL{
    public class Contexto : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
    }
}