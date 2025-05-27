using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;

public class PujasAplicacion : IPujasAplicacion
{
    private string? _conexion;

    // Constructor que recibe la cadena de conexión
    public PujasAplicacion(string conexion)
    {
        _conexion = conexion;
    }

    public void Configurar(string StringConexion)
    {
        _conexion = StringConexion;
    }

    public IEnumerable<Pujas> BuscarPorNombre(string nombre)
    {
        // Implementación real
        return new List<Pujas>(); // temporal
    }

    public List<Pujas> Listar()
    {
        return new List<Pujas>(); // temporal
    }

    public Pujas? Guardar(Pujas? entidad)
    {
        return entidad; // temporal
    }

    public Pujas? Modificar(Pujas? entidad)
    {
        return entidad; // temporal
    }

    public Pujas? Borrar(Pujas? entidad)
    {
        return entidad; // temporal
    }
}
