using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;

public class ProductosAplicacion : IProductosAplicacion
{
    private string? _conexion;

    // Constructor que recibe la cadena de conexión
    public ProductosAplicacion(string conexion)
    {
        _conexion = conexion;
    }

    public void Configurar(string StringConexion)
    {
        _conexion = StringConexion;
    }

    public IEnumerable<Productos> BuscarPorNombre(string nombre)
    {
        // Implementación real
        return new List<Productos>(); // temporal
    }

    public List<Productos> Listar()
    {
        return new List<Productos>(); // temporal
    }

    public Productos? Guardar(Productos? entidad)
    {
        return entidad; // temporal
    }

    public Productos? Modificar(Productos? entidad)
    {
        return entidad; // temporal
    }

    public Productos? Borrar(Productos? entidad)
    {
        return entidad; // temporal
    }
}
