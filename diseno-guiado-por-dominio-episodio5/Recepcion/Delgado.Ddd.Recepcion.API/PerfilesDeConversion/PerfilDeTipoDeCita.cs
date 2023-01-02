using AutoMapper;
using Delgado.Ddd.Recepcion.Compartido.Modelos.TipoDeCita;
using Delgado.Ddd.Recepcion.Dominio.AgregadosSincronizados;

namespace Delgado.Ddd.Recepcion.API.PerfilesDeConversion
{
    public class PerfilDeTipoDeCita : Profile
    {
        public PerfilDeTipoDeCita()
        {
            CreateMap<TipoDeCita, TipoDeCitaDto>()
            .ForMember(dto => dto.TipoCitaId, options => options.MapFrom(src => src.Id));
        }
    }
}
