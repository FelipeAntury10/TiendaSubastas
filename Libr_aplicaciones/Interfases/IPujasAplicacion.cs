using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IPujasAplicacion
    {
        void Configurar(string StringConexion);
        IEnumerable<Pujas> BuscarPorNombre(string nombre);
        List<Pujas> Listar();
        Pujas? Guardar(Pujas? entidad);
        Pujas? Modificar(Pujas? entidad);
        Pujas? Borrar(Pujas? entidad);
    }
}

