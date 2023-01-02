using System;
namespace Delgado.Ddd.Recepcion.Dominio.Excepciones
{
    public class ExcepcionCitaDuplicada: ArgumentException
    {
        public ExcepcionCitaDuplicada(string message, string nombreDelParametro): base(message, nombreDelParametro)
        {
        }
        
    }
}
