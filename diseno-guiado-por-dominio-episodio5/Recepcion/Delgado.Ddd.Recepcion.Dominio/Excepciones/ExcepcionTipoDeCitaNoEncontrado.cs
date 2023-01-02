using System;
namespace Delgado.Ddd.Recepcion.Dominio.Excepciones
{
    public class ExcepcionTipoDeCitaNoEncontrado: Exception
    {
        public ExcepcionTipoDeCitaNoEncontrado(string message): base(message)
        {
        }

        public ExcepcionTipoDeCitaNoEncontrado(int tipoDeCitaId): base ($"El tipo de cita con id [{tipoDeCitaId}] no ha sido encontrada!")
        {

        }
    }
}
