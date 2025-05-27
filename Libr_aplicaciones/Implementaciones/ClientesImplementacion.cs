using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;

public class ClientesAplicacion : IClientesAplicacion
{
    private string? _conexion;

    // Constructor que recibe la cadena de conexión
    public ClientesAplicacion(string conexion)
    {
        _conexion = conexion;
    }

    public void Configurar(string StringConexion)
    {
        _conexion = StringConexion;
    }

    public IEnumerable<Clientes> BuscarPorNombre(string nombre)
    {
        // Implementación real
        return new List<Clientes>(); // temporal
    }

    public List<Clientes> Listar()
    {
        return new List<Clientes>(); // temporal
    }

    public Clientes? Guardar(Clientes? entidad)
    {
        return entidad; // temporal
    }

    public Clientes? Modificar(Clientes? entidad)
    {
        return entidad; // temporal
    }

    public Clientes? Borrar(Clientes? entidad)
    {
        return entidad; // temporal
    }
}
