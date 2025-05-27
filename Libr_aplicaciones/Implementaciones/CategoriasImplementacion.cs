using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;

public class CategoriasAplicacion : ICategoriasAplicacion
{
    private string? _conexion;

    // Constructor que recibe la cadena de conexión
    public CategoriasAplicacion(string conexion)
    {
        _conexion = conexion;
    }

    public void Configurar(string StringConexion)
    {
        _conexion = StringConexion;
    }

    public IEnumerable<Categorias> BuscarPorNombre(string nombre)
    {
        // Implementación real
        return new List<Categorias>(); // temporal
    }

    public List<Categorias> Listar()
    {
        return new List<Categorias>(); // temporal
    }

    public Categorias? Guardar(Categorias? entidad)
    {
        return entidad; // temporal
    }

    public Categorias? Modificar(Categorias? entidad)
    {
        return entidad; // temporal
    }

    public Categorias? Borrar(Categorias? entidad)
    {
        return entidad; // temporal
    }
}

