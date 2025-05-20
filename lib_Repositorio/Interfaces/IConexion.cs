using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Categorias>? Categorias { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Estados>? Estados { get; set; }
        DbSet<MetodosPagos>? MetodosPagos { get; set; }
        DbSet<Pagos>? Pagos { get; set; }
        DbSet<Productos>? Productos { get; set; }
        DbSet<Pujas>? Pujas { get; set; }
        DbSet<Subastas>? Subastas { get; set; }
        DbSet<Vendedores>? Vendedores { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}