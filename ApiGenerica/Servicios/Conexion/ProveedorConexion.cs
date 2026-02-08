using System;
using Microsoft.Extensions.Configuration;
using ApiGenerica.Servicios.Abstracciones;

namespace ApiGenerica.Servicios.Conexion
{
    public class ProveedorConexion : IProveedorConexion
    {
        private readonly IConfiguration _configuracion ;

        public ProveedorConexion(IConfiguration configuracion)
        {
            _configuracion = configuracion ?? throw new ArgumentNullException(
                nameof(configuracion)
            );
        }
        public string ProveedorActual
        {
            get
            {
                var valor = _configuracion.GetValue<string>("DatabaseProvider");
                return string.IsNullOrWhiteSpace(valor)?"SqlServer": valor.Trim();
            }
        }

        public string ObtenerCadenaConexion()
        {
            string? cadena = _configuracion.GetConnectionString(ProveedorActual);
            if (string.IsNullOrWhiteSpace(cadena))
                throw new Exception(
                    $"No se encontró la cadena de conexión para el proveedor '{ProveedorActual}'. " +
                    $"Verificar que existe 'ConnectionStrings:{ProveedorActual}' en appsettings.json " +
                    $"y que 'DatabaseProvider' esté configurado correctamente."

                );
            
            return cadena;
        }

    }
}