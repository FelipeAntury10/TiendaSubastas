using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class MetodosPagosPresentacion : IMetodosPagosPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<MetodosPagos>> Listar()
        {
            var lista = new List<MetodosPagos>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "MetodosPagos/Listar");
            var respuesta = await comunicaciones.Execute(datos);

            if (respuesta.ContainsKey("Error"))
                throw new Exception(respuesta["Error"].ToString()!);

            lista = JsonConversor.ConvertirAObjeto<List<MetodosPagos>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<MetodosPagos>> PorNombre(MetodosPagos? entidad)
        {
            var lista = new List<MetodosPagos>();
            var datos = new Dictionary<string, object> { ["Entidad"] = entidad! };

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "MetodosPagos/PorNombre");
            var respuesta = await comunicaciones.Execute(datos);

            if (respuesta.ContainsKey("Error"))
                throw new Exception(respuesta["Error"].ToString()!);

            lista = JsonConversor.ConvertirAObjeto<List<MetodosPagos>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<MetodosPagos?> Guardar(MetodosPagos? entidad)
        {
            if (entidad!.ID != 0)
                throw new Exception("lbFaltaInformacion");

            var datos = new Dictionary<string, object> { ["Entidad"] = entidad };

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "MetodosPagos/Guardar");
            var respuesta = await comunicaciones.Execute(datos);

            if (respuesta.ContainsKey("Error"))
                throw new Exception(respuesta["Error"].ToString()!);

            entidad = JsonConversor.ConvertirAObjeto<MetodosPagos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<MetodosPagos?> Modificar(MetodosPagos? entidad)
        {
            if (entidad!.ID == 0)
                throw new Exception("lbFaltaInformacion");

            var datos = new Dictionary<string, object> { ["Entidad"] = entidad };

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "MetodosPagos/Modificar");
            var respuesta = await comunicaciones.Execute(datos);

            if (respuesta.ContainsKey("Error"))
                throw new Exception(respuesta["Error"].ToString()!);

            entidad = JsonConversor.ConvertirAObjeto<MetodosPagos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<MetodosPagos?> Borrar(MetodosPagos? entidad)
        {
            if (entidad!.ID == 0)
                throw new Exception("lbFaltaInformacion");

            var datos = new Dictionary<string, object> { ["Entidad"] = entidad };

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "MetodosPagos/Borrar");
            var respuesta = await comunicaciones.Execute(datos);

            if (respuesta.ContainsKey("Error"))
                throw new Exception(respuesta["Error"].ToString()!);

            entidad = JsonConversor.ConvertirAObjeto<MetodosPagos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}
