using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;

public class VendedoresAplicacion : IVendedoresAplicacion
{
    private string? _conexion;

    // Constructor que recibe la cadena de conexión
    public VendedoresAplicacion(string conexion)
    {
        _conexion = conexion;
    }

    public void Configurar(string StringConexion)
    {
        _conexion = StringConexion;
    }

    public IEnumerable<Vendedores> BuscarPorNombre(string nombre)
    {
        // Implementación real
        return new List<Vendedores>(); // temporal
    }

    public List<Vendedores> Listar()
    {
        return new List<Vendedores>(); // temporal
    }

    public Vendedores? Guardar(Vendedores? entidad)
    {
        return entidad; // temporal
    }

    public Vendedores? Modificar(Vendedores? entidad)
    {
        return entidad; // temporal
    }

    public Vendedores? Borrar(Vendedores? entidad)
    {
        return entidad; // temporal
    }
}
