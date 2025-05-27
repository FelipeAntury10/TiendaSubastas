using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IPagosAplicacion
    {
        void Configurar(string StringConexion);
        IEnumerable<Pagos> BuscarPorNombre(string nombre);
        List<Pagos> Listar();
        Pagos? Guardar(Pagos? entidad);
        Pagos? Modificar(Pagos? entidad);
        Pagos? Borrar(Pagos? entidad);
    }
}
