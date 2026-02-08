using System;

namespace ApiGenerica.Servicios.Abstracciones
{
    public interface IProveedorConexion
    {
        string ProveedorActual {get;}
        string ObtenerCadenaConexion();
    }
}