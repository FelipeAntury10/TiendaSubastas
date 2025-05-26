using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class CategoriasPresentacion : ICategoriasPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<Categorias>> Listar()
        {
            var lista = new List<Categorias>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Categorias/Listar");
            var respuesta = await comunicaciones!.Execute(datos);

            if (respuesta.ContainsKey("Error"))
                throw new Exception(respuesta["Error"]!.ToString());

            lista = JsonConversor.ConvertirAObjeto<List<Categorias>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));

            return lista;
        }

        public async Task<List<Categorias>> PorNombre(Categorias categoria)
        {
            var lista = new List<Categorias>();
            var datos = new Dictionary<string, object>
            {
                ["Entidad"] = categoria
            };

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Categorias/PorNombre");
            var respuesta = await comunicaciones!.Execute(datos);

            if (respuesta.ContainsKey("Error"))
                throw new Exception(respuesta["Error"]!.ToString());

            lista = JsonConversor.ConvertirAObjeto<List<Categorias>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));

            return lista;
        }

        public async Task<Categorias?> Guardar(Categorias? categoria)
        {
            if (categoria == null || categoria.ID != 0)
                throw new Exception("lbFaltaInformacion");

            var datos = new Dictionary<string, object>
            {
                ["Entidad"] = categoria
            };

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Categorias/Guardar");
            var respuesta = await comunicaciones!.Execute(datos);

            if (respuesta.ContainsKey("Error"))
                throw new Exception(respuesta["Error"]!.ToString());

            categoria = JsonConversor.ConvertirAObjeto<Categorias>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));

            return categoria;
        }

        public async Task<Categorias?> Modificar(Categorias? categoria)
        {
            if (categoria == null || categoria.ID == 0)
                throw new Exception("lbFaltaInformacion");

            var datos = new Dictionary<string, object>
            {
                ["Entidad"] = categoria
            };

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Categorias/Modificar");
            var respuesta = await comunicaciones!.Execute(datos);

            if (respuesta.ContainsKey("Error"))
                throw new Exception(respuesta["Error"]!.ToString());

            categoria = JsonConversor.ConvertirAObjeto<Categorias>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));

            return categoria;
        }

        public async Task<Categorias?> Borrar(Categorias? categoria)
        {
            if (categoria == null || categoria.ID == 0)
                throw new Exception("lbFaltaInformacion");

            var datos = new Dictionary<string, object>
            {
                ["Entidad"] = categoria
            };

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Categorias/Borrar");
            var respuesta = await comunicaciones!.Execute(datos);

            if (respuesta.ContainsKey("Error"))
                throw new Exception(respuesta["Error"]!.ToString());

            categoria = JsonConversor.ConvertirAObjeto<Categorias>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));

            return categoria;
        }
    }
}
