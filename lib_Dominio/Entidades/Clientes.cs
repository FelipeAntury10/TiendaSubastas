using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Clientes
    {
        [Key] public int ID { get; set; }
        public string? Nombre { get; set; }
        public string? Cedula { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }

        //Envia
        //public List<Pujas> Pujas { get; set; } = new List<Pujas>();
        //public List<Pagos> Pagos { get; set; } = new List<Pagos>();
    }
}
