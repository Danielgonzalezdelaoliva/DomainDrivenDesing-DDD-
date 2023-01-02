using System.Linq;
using AutoMapper;
using Delgado.Ddd.Recepcion.Compartido.Modelos.Calendario;
using Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario;

namespace Delgado.Ddd.Recepcion.API.PerfilesDeConversion
{
    public class PerfilDeCalendario: Profile
    {
        public PerfilDeCalendario()
        {
            CreateMap<Calendario, CalendarioDto>()
                .ForPath(dto => dto.CitaIds, options => options.MapFrom(src => src.Citas.Select(x => x.Id)));

            CreateMap<CalendarioDto, Calendario>();
            CreateMap<LlamadaCrearCalendario, Calendario>();
        }
    }
}
