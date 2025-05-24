using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_presentacion.Pages.Ventanas
{
    public class PujasModel : PageModel
    {
        private readonly IPujasPresentacion iPresentacion;

        public PujasModel(IPujasPresentacion iPresentacion)
        {
            this.iPresentacion = iPresentacion;
            Filtro = new Pujas();
        }

        [BindProperty]
        public Enumerables.Ventanas Accion { get; set; }

        [BindProperty]
        public Pujas? Actual { get; set; }

        [BindProperty]
        public Pujas? Filtro { get; set; }

        [BindProperty]
        public List<Pujas>? Lista { get; set; }

        public virtual void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Usuario");
                if (string.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                // Aquí filtramos por ProductoId si se quiere, o sin filtro (a definir)
                // Por ejemplo, si Filtro.ProductoId tiene valor, lo usamos para filtrar
                int productoId = Filtro?.ProductoId ?? 0;

                Accion = Enumerables.Ventanas.Listas;

                Task<List<Pujas>> task;

                if (productoId > 0)
                    task = iPresentacion.PorProducto(productoId);
                else
                    task = Task.FromResult(new List<Pujas>()); // O implementar otro método para listar todas las pujas

                task.Wait();
                Lista = task.Result;
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                Actual = new Pujas { Fecha = DateTime.Now };
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtModificar(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.ID.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;

                Task<Pujas?>? task = Actual!.ID == 0
                    ? iPresentacion.Guardar(Actual!)
                    : iPresentacion.Modificar(Actual!);

                task.Wait();
                Actual = task.Result;
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.ID.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                var task = iPresentacion.Borrar(Actual!);
                Actual = task.Result;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCancelar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCerrar()
        {
            try
            {
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
