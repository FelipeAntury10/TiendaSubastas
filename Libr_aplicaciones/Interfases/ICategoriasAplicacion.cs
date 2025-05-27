using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface ICategoriasAplicacion
    {
        void Configurar(string StringConexion);
        IEnumerable<Categorias> BuscarPorNombre(string nombre);
        List<Categorias> Listar();
        Categorias? Guardar(Categorias? entidad);
        Categorias? Modificar(Categorias? entidad);
        Categorias? Borrar(Categorias? entidad);
    }
}
