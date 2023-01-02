using System;
namespace Delgado.Ddd.Recepcion.Dominio.Excepciones
{
    public class ExcepcionCalendarioNoEncontrado: Exception
    {
        public ExcepcionCalendarioNoEncontrado(string message):base (message)
        {
        }

        public ExcepcionCalendarioNoEncontrado(Guid calendarioId): base($"El calendario con Id: [{calendarioId}] no ha sido encontrado")
        {

        }
    }
}
