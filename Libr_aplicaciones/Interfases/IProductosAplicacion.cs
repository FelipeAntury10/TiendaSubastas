using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IProductosAplicacion
    {
        void Configurar(string StringConexion);
        IEnumerable<Productos> BuscarPorNombre(string nombre);
        List<Productos> Listar();
        Productos? Guardar(Productos? entidad);
        Productos? Modificar(Productos? entidad);
        Productos? Borrar(Productos? entidad);
    }
}

