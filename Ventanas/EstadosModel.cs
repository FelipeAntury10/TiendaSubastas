using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Ventanas
{
    public class EstadosModel : PageModel
    {
        private IEstadosPresentacion? iPresentacion = null;

        public EstadosModel(IEstadosPresentacion iPresentacion)
        {
            this.iPresentacion = iPresentacion;
            Filtro = new Estados();
        }

        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Estados? Actual { get; set; }
        [BindProperty] public Estados? Filtro { get; set; }
        [BindProperty] public List<Estados>? Lista { get; set; }

        public void OnGet() { OnPostBtRefrescar(); }

        public void OnPostBtRefrescar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                var task = iPresentacion!.BuscarPorNombre(Filtro!);
                task.Wait();
                Lista = task.Result;
                Actual = null;
            }
            catch (Exception ex) { LogConversor.Log(ex, ViewData!); }
        }

        public void OnPostBtNuevo()
        {
            Accion = Enumerables.Ventanas.Editar;
            Actual = new Estados();
        }

        public void OnPostBtModificar(string data)
        {
            OnPostBtRefrescar();
            Accion = Enumerables.Ventanas.Editar;
            Actual = Lista!.FirstOrDefault(x => x.ID.ToString() == data);
        }

        public void OnPostBtGuardar()
        {
            Task<Estados>? task = (Actual!.ID == 0) ? iPresentacion!.Guardar(Actual!) : iPresentacion!.Modificar(Actual!);
            task.Wait();
            Actual = task.Result;
            Accion = Enumerables.Ventanas.Listas;
            OnPostBtRefrescar();
        }

        public void OnPostBtBorrarVal(string data)
        {
            OnPostBtRefrescar();
            Accion = Enumerables.Ventanas.Borrar;
            Actual = Lista!.FirstOrDefault(x => x.ID.ToString() == data);
        }

        public void OnPostBtBorrar()
        {
            var task = iPresentacion!.Borrar(Actual!);
            Actual = task.Result;
            OnPostBtRefrescar();
        }

        public void OnPostBtCancelar() => OnPostBtRefrescar();
        public void OnPostBtCerrar() => OnPostBtRefrescar();
    }
}