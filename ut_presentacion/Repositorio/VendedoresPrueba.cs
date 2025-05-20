using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorio
{
    [TestClass]
    public class VendedoresPrueba
    {
        private readonly IConexion? iConexion;
        private List<Pagos>? lista;
        private Pagos? entidad;

        public VendedoresPrueba()
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
            entidad = EntidadesNucleo.Pagos()!;
            var _Cliente = this.iConexion!.Clientes!.FirstOrDefault(x => x.ID == 1);
            var _Subasta = this.iConexion!.Subastas!.FirstOrDefault(x => x.ID == 1);
            var _MetodoPago = this.iConexion!.MetodosPagos!.FirstOrDefault(x => x.ID == 1);
            entidad!.ClientesID = _Cliente.ID;
            entidad!.SubastasID = _Subasta.ID;
            entidad!.MetodosPagosID = _MetodoPago.ID;
            return true;
        }

        public bool Listar()
        {
            lista = iConexion!.Pagos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            iConexion!.Pagos!.Add(entidad);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidad!.Referencia = "Pepe";

            var entry = iConexion!.Entry<Pagos>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Pagos!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}