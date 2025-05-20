using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Pagos
    {
        [Key] public int ID { get; set; }
        public string? Referencia { get; set; }
        public int? ClientesID { get; set; } //ClienteID -> ClientesID para la migracion
        public int? SubastasID { get; set; }
        public int? MetodosPagosID { get; set; }

        //Recibe 
        public Clientes? _Cliente { get; set; }
        public Subastas? _Subasta { get; set; }
        public MetodosPagos? _MetodoPago { get; set; }
    }
}
