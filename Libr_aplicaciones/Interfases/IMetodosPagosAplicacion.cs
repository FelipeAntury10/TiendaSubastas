using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IMetodosPagosAplicacion
    {
        void Configurar(string StringConexion);
        IEnumerable<MetodosPagos> BuscarPorNombre(string nombre);
        List<MetodosPagos> Listar();
        MetodosPagos? Guardar(MetodosPagos? entidad);
        MetodosPagos? Modificar(MetodosPagos? entidad);
        MetodosPagos? Borrar(MetodosPagos? entidad);
        
        
        
    }
}
