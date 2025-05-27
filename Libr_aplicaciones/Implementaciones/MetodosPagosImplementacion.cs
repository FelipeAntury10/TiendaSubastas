using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;

public class MetodosPagosAplicacion : IMetodosPagosAplicacion
{
    private string? _conexion;

    // Constructor que recibe la cadena de conexión
    public MetodosPagosAplicacion(string conexion)
    {
        _conexion = conexion;
    }

    public void Configurar(string StringConexion)
    {
        _conexion = StringConexion;
    }

    public IEnumerable<MetodosPagos> BuscarPorNombre(string nombre)
    {
        // Implementación real
        return new List<MetodosPagos>(); // temporal
    }

    public List<MetodosPagos> Listar()
    {
        return new List<MetodosPagos>(); // temporal
    }

    public MetodosPagos? Guardar(MetodosPagos? entidad)
    {
        return entidad; // temporal
    }

    public MetodosPagos? Modificar(MetodosPagos? entidad)
    {
        return entidad; // temporal
    }

    public MetodosPagos? Borrar(MetodosPagos? entidad)
    {
        return entidad; // temporal
    }
}