using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<Categorias>? Categorias { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Estados>? Estados { get; set; }
        public DbSet<MetodosPagos>? MetodosPagos { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Pujas>? Pujas { get; set; }
        public DbSet<Subastas>? Subastas { get; set; }
        public DbSet<Vendedores>? Vendedores { get; set; }


    }
}