using System;
using Ardalis.GuardClauses;
using Delgado.Ddd.KernellCompartido;
using Delgado.Ddd.KernellCompartido.Interfaces;

namespace Delgado.Ddd.Recepcion.Dominio.AgregadosSincronizados
{
    public class TipoDeCita: EntidadBase<int>, IRaizDeAgregado
    {
        public TipoDeCita(int id, string nombre)
        {
            Id = Guard.Against.NegativeOrZero(id, nameof(id));
            Nombre = Guard.Against.NullOrEmpty(nombre, nameof(nombre));
        }

        public TipoDeCita(int id, string nombre, int duracion)
        {
            Id = Guard.Against.NegativeOrZero(id, nameof(id));
            Nombre = Guard.Against.NullOrEmpty(nombre, nameof(nombre));
            Duracion = Guard.Against.NegativeOrZero(duracion, nameof(duracion));
        }

        public string Nombre { get; private set; }
        public int Duracion { get; private set; }
    }
}
