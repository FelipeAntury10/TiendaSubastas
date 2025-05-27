using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;

public class PagosAplicacion : IPagosAplicacion
{
    private string? _conexion;

    // Constructor que recibe la cadena de conexión
    public PagosAplicacion(string conexion)
    {
        _conexion = conexion;
    }

    public void Configurar(string StringConexion)
    {
        _conexion = StringConexion;
    }

    public IEnumerable<Pagos> BuscarPorNombre(string nombre)
    {
        // Implementación real
        return new List<Pagos>(); // temporal
    }

    public List<Pagos> Listar()
    {
        return new List<Pagos>(); // temporal
    }

    public Pagos? Guardar(Pagos? entidad)
    {
        return entidad; // temporal
    }

    public Pagos? Modificar(Pagos? entidad)
    {
        return entidad; // temporal
    }

    public Pagos? Borrar(Pagos? entidad)
    {
        return entidad; // temporal
    }
}