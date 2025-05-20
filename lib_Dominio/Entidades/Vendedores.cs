using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Vendedores
    {
        [Key] public int ID { get; set; }
        public string? Nombre { get; set; }
        public string? Cedula { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }

        //Envia
        //public List<Subastas> Subastas { get; set; } = new List<Subastas>();
    }
}
