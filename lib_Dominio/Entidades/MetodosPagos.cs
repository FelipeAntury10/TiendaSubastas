using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class MetodosPagos
    {
        [Key] public int ID { get; set; }
        public string? TipoPago { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        //Envia
        //public List<Pagos> Pagos { get; set; } = new List<Pagos>();
    }
}
