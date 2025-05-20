using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Categorias? Categorias()
        {
            var entidad = new Categorias();
            entidad.Nombre = "Categoría Default";
            entidad.Descripcion = "Descripcion Default";
            return entidad;
        }
        public static Clientes? Clientes()
        {
            var entidad = new Clientes();
            entidad.Nombre = "Cliente Default";
            entidad.Cedula= "0000000000";
            entidad.Email= "cliente@example.com";
            entidad.Telefono = "00000000000";
            return entidad;
        }
        public static Estados? Estados()
        {
            var entidad = new Estados();
            entidad.Nombre = "Estado Default";
            entidad.Descripcion= "Estado Inicial";
            return entidad;
        }
        public static MetodosPagos? MetodosPagos()
        {
            var entidad = new MetodosPagos();
            entidad.Nombre = "MetodoPago Default";
            entidad.TipoPago = "Default";
            entidad.Descripcion = "MetodoPago Inicial";
            return entidad;
        }
        public static Pagos? Pagos()
        {
            var entidad = new Pagos();
            entidad.Referencia = "Referencia De Pago";
            return entidad;
        }
        public static Productos? Productos()
        {
            var entidad = new Productos();
            entidad.Nombre = "Producto Default";
            entidad.Descripcion = "Producto Inicial";
            entidad.PrecioInicial = 1231231123;
            return entidad;
        }
        public static Pujas? Pujas()
        {
            var entidad = new Pujas();
            entidad.Monto = 000000;
            entidad.Fecha = DateTime.Now;
            return entidad;
        }
        public static Subastas? Subastas()
        {
            var entidad = new Subastas();
            entidad.FechaInicio= DateTime.Now;
            entidad.FechaFin=DateTime.Now;
            return entidad;
        }
        public static Vendedores? Vendedores()
        {
            var entidad = new Vendedores();
            entidad.Nombre = "Vendedor Default";
            entidad.Cedula = "0000000000";
            entidad.Email = "cliente@example.com";
            entidad.Telefono = "00000000000";
            entidad.Direccion = "Direccion Default";
            return entidad;
        }
    }
}