using System.Threading.Tasks;

namespace Delgado.Ddd.Recepcion.Dominio.Interfaces
{
    public interface IEnvioDeCorreo
    {
        Task EnviarCorreoElectronicoAsync(string para, string de, string tema, string contenido);
    }
}
