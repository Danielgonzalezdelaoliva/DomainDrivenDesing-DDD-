using System;
using System.Collections.Generic;

namespace Delgado.Ddd.KernellCompartido
{
    public class RangoDeFechaTiempo : ObjetoDeValor
    {
        public DateTime Comienzo { get; private set; }
        public DateTime Fin { get; private set; }

        public RangoDeFechaTiempo(DateTime comienzo, DateTime fin)
        {
            if (fin <= comienzo)
                throw new ArgumentOutOfRangeException();

            Comienzo = comienzo;
            Fin = fin;
                
        }

        public RangoDeFechaTiempo(DateTime comienzo, TimeSpan duracion) : this(comienzo, comienzo.Add(duracion))
        {
        }
        

        public int DurationInMinutes()
        {
            return (int)Math.Round((Fin - Comienzo).TotalMinutes, 0);
        }

        public RangoDeFechaTiempo NewDuration(TimeSpan newDuration)
        {
            return new RangoDeFechaTiempo(this.Comienzo, newDuration);
        }

        public RangoDeFechaTiempo NewEnd(DateTime newEnd)
        {
            return new RangoDeFechaTiempo(this.Comienzo, newEnd);
        }

        public RangoDeFechaTiempo NewStart(DateTime newStart)
        {
            return new RangoDeFechaTiempo(newStart, this.Fin);
        }

        public static RangoDeFechaTiempo CreateOneDayRange(DateTime day)
        {
            return new RangoDeFechaTiempo(day, day.AddDays(1));
        }

        public static RangoDeFechaTiempo CreateOneWeekRange(DateTime startDay)
        {
            return new RangoDeFechaTiempo(startDay, startDay.AddDays(7));
        }

        public bool Overlaps(RangoDeFechaTiempo dateTimeRange)
        {
            return this.Comienzo < dateTimeRange.Fin &&
                this.Fin > dateTimeRange.Comienzo;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Comienzo;
            yield return Fin;
        }
    }
}
