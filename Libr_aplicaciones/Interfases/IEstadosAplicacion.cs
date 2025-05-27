using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IEstadosAplicacion
    {
        void Configurar(string StringConexion);
        IEnumerable<Estados> BuscarPorNombre(string nombre);
        List<Estados> Listar();
        Estados? Guardar(Estados? entidad);
        Estados? Modificar(Estados? entidad);
        Estados? Borrar(Estados? entidad);
       
       
       
    }
}