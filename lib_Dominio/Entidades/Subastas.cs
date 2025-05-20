using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Subastas
    {
        [Key] public int ID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int CategoriasID { get; set; }
        public int ProductosID { get; set; }
        public int VendedoresID { get; set; }
        public int EstadosID { get; set; }

        //Recibe
        public Productos? _Producto { get; set; }
        public Vendedores? _Vendedor { get; set; }
        public Estados? _Estado { get; set; }
        public Categorias? _Categoria { get; set; }

        //Envia
        //public List<Pujas> Pujas { get; set; } = new List<Pujas>();
    }
}
