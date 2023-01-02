using Delgado.Ddd.KernellCompartido;
using Delgado.Ddd.KernellCompartido.Interfaces;

namespace Delgado.Ddd.Recepcion.Dominio.AgregadosSincronizados
{
    public class Peluquero : EntidadBase<int>, IRaizDeAgregado
    {
        public Peluquero(int id)
        {
            Id = id;
        }

        public string NombreCompleto { get; private set; }

        //Omitiendo otra informacion por brevedad en el episodio.
    }
}
