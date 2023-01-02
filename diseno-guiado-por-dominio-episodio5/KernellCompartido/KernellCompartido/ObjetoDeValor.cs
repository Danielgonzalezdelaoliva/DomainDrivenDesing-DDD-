using System;
using System.Collections.Generic;
using System.Linq;

namespace Delgado.Ddd.KernellCompartido
{
    [Serializable]
    public abstract class ObjetoDeValor: IComparable, IComparable<ObjetoDeValor>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public ObjetoDeValor()
        {
        }

        
        public int CompareTo(ObjetoDeValor other)
        {
            return CompareTo(other as object);
        }

        public int CompareTo(object obj)
        {
            var other = (ObjetoDeValor)obj;

            object[] components = GetEqualityComponents().ToArray();
            object[] otherComponents = other.GetEqualityComponents().ToArray();

            for (int i = 0; i < components.Length; i++)
            {
                int comparison = CompareComponents(components[i], otherComponents[i]);
                if (comparison != 0)
                    return comparison;
            }

            return 0;
        }

        private int CompareComponents(object object1, object object2)
        {
            if (object1 is null && object2 is null)
                return 0;

            if (object1 is null)
                return -1;

            if (object2 is null)
                return 1;

            if (object1 is IComparable comparable1 && object2 is IComparable comparable2)
                return comparable1.CompareTo(comparable2);

            return object1.Equals(object2) ? 0 : -1;
        }
    }
}
