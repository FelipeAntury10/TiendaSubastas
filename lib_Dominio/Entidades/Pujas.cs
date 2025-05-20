using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Pujas
    {
        [Key] public int ID { get; set; }
        public decimal? Monto { get; set; }
        public DateTime? Fecha { get; set; }
        public int ClientesID { get; set; }
        public int SubastasID { get; set; }

        //Recibe
        public Clientes? _Cliente { get; set; }
        public Subastas? _Subasta { get; set; }
    }
}
