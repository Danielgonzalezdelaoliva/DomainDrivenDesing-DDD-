using Delgado.Ddd.KernellCompartido;
using Delgado.Ddd.KernellCompartido.Interfaces;

namespace Delgado.Ddd.Recepcion.Dominio.AgregadosSincronizados
{
    public class Cliente: EntidadBase<int>, IRaizDeAgregado
    {
        public Cliente(int id)
        {
            Id = id;
        }

        public Cliente(string nombreComplete, string correoElectronico, string numeroDeTelefono, int peluqueroFavoritoId)
        {
            NombreCompleto = nombreComplete;
            CorreoElectronico = correoElectronico;
            NumeroDeTelefono = numeroDeTelefono;
            PeluqueroFavoritoId = peluqueroFavoritoId;
        }

        public string NombreCompleto { get; private set; }
        public string CorreoElectronico { get; private set; }
        public string NumeroDeTelefono { get; private set; }
        public int PeluqueroFavoritoId { get; private set; }

        public override string ToString()
        {
            return NombreCompleto.ToString();
        }
    }
}
