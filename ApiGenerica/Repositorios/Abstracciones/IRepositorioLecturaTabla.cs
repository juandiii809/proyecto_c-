using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiGenerica.Repositorios.Abtracciones
{
    public interface IRepositorioLecturaTabla
    {
        Task <IReadOnlyList<Dictionary<string, object?>>> ObtenerFilasAsync(
            string NombreTabla,
            string? esquema,
            int? Limite
        );

        Task <IReadOnlyList<Dictionary<string, object?>>> ObtenerPorClaveAsync(
            string NombreTabla,
            string? esquema,
            string NombreClave,
            string Valor
        );

        Task<bool> CrearAsync(
            string NombreTabla,
            string? esquema,
            Dictionary<string, object> datos,
            string? CamposEncriptar = null
        );

        Task<int> ActualizarAsync(
            string NombreTabla,
            string? esquema,
            string NombreClave,
            string ValorClave,
            Dictionary<string, object?> datos,
            string? CamposEncriptar = null
        );

        Task<int> EliminarAsync(
            string NombreTabla,
            string? esquema,
            string NombreClave,
            string ValorClave
        );

        Task<string?> ObtenerHashContraseñaAsync(
            string NombreTabla,
            string? esquema,
            string CampoUsuario,
            string CampoContraseña,
            string ValorUsuario
        );

        Task<Dictionary<string, object?>> ObtenerDiagnosticoConexionAsync();
    }
}