using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface ISubastasAplicacion
    {
        void Configurar(string StringConexion);
        IEnumerable<Subastas> BuscarPorNombre(string nombre);
        List<Subastas> Listar();
        Subastas? Guardar(Subastas? entidad);
        Subastas? Modificar(Subastas? entidad);
        Subastas? Borrar(Subastas? entidad);
    }
}


