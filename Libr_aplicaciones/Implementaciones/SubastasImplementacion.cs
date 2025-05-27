using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;

public class SubastasAplicacion : ISubastasAplicacion
{
    private string? _conexion;

    // Constructor que recibe la cadena de conexión
    public SubastasAplicacion(string conexion)
    {
        _conexion = conexion;
    }

    public void Configurar(string StringConexion)
    {
        _conexion = StringConexion;
    }

    public IEnumerable<Subastas> BuscarPorNombre(string nombre)
    {
        // Implementación real
        return new List<Subastas>(); // temporal
    }

    public List<Subastas> Listar()
    {
        return new List<Subastas>(); // temporal
    }

    public Subastas? Guardar(Subastas? entidad)
    {
        return entidad; // temporal
    }

    public Subastas? Modificar(Subastas? entidad)
    {
        return entidad; // temporal
    }

    public Subastas? Borrar(Subastas? entidad)
    {
        return entidad; // temporal
    }
}
