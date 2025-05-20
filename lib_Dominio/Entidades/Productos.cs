using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Productos
    {
        [Key] public int ID { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? PrecioInicial { get; set; }
        public int? CategoriasID { get; set; }

        //Recibe
        public Categorias? _Categoria { get; set; }

        //Envia
        //public List<Subastas> Subastas { get; set; } = new List<Subastas>();
    }
}
