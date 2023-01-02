using System.Threading.Tasks;

namespace Delgado.Ddd.Recepcion.Dominio.Interfaces
{
    public interface ISistemaDeArchivo
    {
        Task<bool> GuardarFoto(string nombreDeFoto, string fotoBase64);
    }
}
