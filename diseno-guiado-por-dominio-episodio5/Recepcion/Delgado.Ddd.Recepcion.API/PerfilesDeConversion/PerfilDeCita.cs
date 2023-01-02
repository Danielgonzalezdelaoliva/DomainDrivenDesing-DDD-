using AutoMapper;
using Delgado.Ddd.Recepcion.Compartido.Modelos.Cita;
using Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario;

namespace Delgado.Ddd.Recepcion.API.PerfilesDeConversion
{
    public class PerfilDeCita: Profile
    {
        public PerfilDeCita()
        {
            CreateMap<Cita, CitaDto>()
            .ForMember(dto => dto.CitaId, options => options.MapFrom(src => src.Id))
            .ForMember(dto => dto.ClienteId, options => options.MapFrom(src => src.ClienteId))
            .ForMember(dto => dto.Comienzo, options => options.MapFrom(src => src.RangoDeFechaTiempo.Comienzo))
            .ForMember(dto => dto.Fin, options => options.MapFrom(src => src.RangoDeFechaTiempo.Fin));

            CreateMap<CitaDto, Cita>()
                .ForPath(src => src.RangoDeFechaTiempo.Comienzo, options => options.MapFrom(dto => dto.Comienzo))
                .ForPath(src => src.RangoDeFechaTiempo.Fin, options => options.MapFrom(dto => dto.Fin));

            CreateMap<LlamadaCrearCita, Cita>()
            .ForPath(cita => cita.RangoDeFechaTiempo.Comienzo, options => options.MapFrom(llamada => llamada.FechaDeCita))
            .ForPath(cita => cita.RangoDeFechaTiempo.Fin, options => options.MapFrom(llamada => llamada.FechaDeCita));          
        }
    }
}
