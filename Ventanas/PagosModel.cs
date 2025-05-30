using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace asp_presentacion.Pages.Ventanas
{
    public class PagosModel : PageModel
    {
        private readonly IPagosPresentacion _pagosPresentacion;
        private readonly IClientesPresentacion _clienteService;
        private readonly ISubastasPresentacion _subastaService;
        private readonly IMetodosPagosPresentacion _metodoPagoService;

        public PagosModel(
            IPagosPresentacion pagosPresentacion,
            IClientesPresentacion clienteService,
            ISubastasPresentacion subastaService,
            IMetodosPagosPresentacion metodoPagoService)
        {
            _pagosPresentacion = pagosPresentacion;
            _clienteService = clienteService;
            _subastaService = subastaService;
            _metodoPagoService = metodoPagoService;
            Filtro = new Pagos();
            ClientesList = new SelectList(Enumerable.Empty<SelectListItem>());
            SubastasList = new SelectList(Enumerable.Empty<SelectListItem>());
            MetodosPagosList = new SelectList(Enumerable.Empty<SelectListItem>());
        }

        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Pagos? Actual { get; set; }
        [BindProperty] public Pagos? Filtro { get; set; }
        [BindProperty] public List<Pagos>? Lista { get; set; }

        public SelectList ClientesList { get; set; }
        public SelectList SubastasList { get; set; }
        public SelectList MetodosPagosList { get; set; }

        public async Task OnGetAsync()
        {
            await LoadSelectListsAsync();
            await OnPostBtRefrescarAsync();
        }

        public async Task OnPostBtRefrescarAsync()
        {
            try
            {
                var session = HttpContext.Session.GetString("Usuario");
                if (string.IsNullOrEmpty(session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Filtro!.Referencia = Filtro?.Referencia ?? "";

                Accion = Enumerables.Ventanas.Listas;
                Lista = await _pagosPresentacion.BuscarPorReferencia(Filtro!);
                Actual = null;

                await LoadSelectListsAsync();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public async Task OnPostBtNuevoAsync()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                Actual = new Pagos { FechaPago = DateTime.Now };
                await LoadSelectListsAsync();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public async Task OnPostBtModificarAsync(string data)
        {
            try
            {
                await OnPostBtRefrescarAsync();
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.ID.ToString() == data);
                await LoadSelectListsAsync();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public async Task OnPostBtGuardarAsync()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;

                var result = Actual!.ID == 0
                    ? await _pagosPresentacion.Guardar(Actual!)
                    : await _pagosPresentacion.Modificar(Actual!);

                Actual = result;
                Accion = Enumerables.Ventanas.Listas;
                await OnPostBtRefrescarAsync();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public async Task OnPostBtBorrarValAsync(string data)
        {
            try
            {
                await OnPostBtRefrescarAsync();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.ID.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public async Task OnPostBtBorrarAsync()
        {
            try
            {
                var result = await _pagosPresentacion.Borrar(Actual!);
                Actual = result;
                await OnPostBtRefrescarAsync();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public async Task OnPostBtCancelarAsync()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                await OnPostBtRefrescarAsync();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public async Task OnPostBtCerrarAsync()
        {
            try
            {
                if (Accion == Enumerables.Ventanas.Listas)
                    await OnPostBtRefrescarAsync();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        private async Task LoadSelectListsAsync()
        {
            try
            {
                var clientes = await _clienteService.GetAllAsync();
                ClientesList = new SelectList(clientes, "ID", "Nombre");

                var subastas = await _subastaService.GetAllAsync();
                SubastasList = new SelectList(subastas, "ID", "Titulo");

                var metodosPago = await _metodoPagoService.GetAllAsync();
                MetodosPagosList = new SelectList(metodosPago, "ID", "Nombre");
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                // Mantener las listas vacías si hay error
                ClientesList = new SelectList(Enumerable.Empty<SelectListItem>());
                SubastasList = new SelectList(Enumerable.Empty<SelectListItem>());
                MetodosPagosList = new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
    }
}