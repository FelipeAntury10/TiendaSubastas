using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Estados
    {
        public int ID { get; set; }
        public string? Descripcion { get; set; }
        public string? Nombre { get; set; }

        //Envia
        //public List<Subastas> Subastas { get; set; } = new List<Subastas>();
    }
}
