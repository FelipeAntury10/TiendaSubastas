using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorio
{
    [TestClass]
    public class ProductosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Productos>? lista;
        private Productos? entidad;

        public ProductosPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Relaciones());
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }
        public bool Relaciones()
        {
            entidad = EntidadesNucleo.Productos()!;
            var _Categorias = this.iConexion!.Categorias!.FirstOrDefault(x => x.ID == 3);
            entidad!.CategoriasID = _Categorias.ID;
            return true;
        }

        public bool Listar()
        {
            lista = iConexion!.Productos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            iConexion!.Productos!.Add(this.entidad);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidad!.Nombre = "Pepe";

            var entry = iConexion!.Entry<Productos>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Productos!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}