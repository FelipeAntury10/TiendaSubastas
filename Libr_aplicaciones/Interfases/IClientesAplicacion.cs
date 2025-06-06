﻿using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IClientesAplicacion
    {
        void Configurar(string StringConexion);
        IEnumerable<Clientes> BuscarPorNombre(string nombre);

        List<Clientes> Listar();
        Clientes? Guardar(Clientes? entidad);
        Clientes? Modificar(Clientes? entidad);
        Clientes? Borrar(Clientes? entidad);
        
    }
}