using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;

public class EstadosAplicacion : IEstadosAplicacion
{
    private string? _conexion;

    // Constructor que recibe la cadena de conexión
    public EstadosAplicacion(string conexion)
    {
        _conexion = conexion;
    }

    public void Configurar(string StringConexion)
    {
        _conexion = StringConexion;
    }

    public IEnumerable<Estados> BuscarPorNombre(string nombre)
    {
        // Implementación real
        return new List<Estados>(); // temporal
    }

    public List<Estados> Listar()
    {
        return new List<Estados>(); // temporal
    }

    public Estados? Guardar(Estados? entidad)
    {
        return entidad; // temporal
    }

    public Estados? Modificar(Estados? entidad)
    {
        return entidad; // temporal
    }

    public Estados? Borrar(Estados? entidad)
    {
        return entidad; // temporal
    }
}