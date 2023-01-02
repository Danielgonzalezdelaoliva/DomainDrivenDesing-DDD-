using System;
using AutoMapper;
using Delgado.Ddd.Recepcion.Compartido.Modelos.Cliente;
using Delgado.Ddd.Recepcion.Dominio.AgregadosSincronizados;

namespace Delgado.Ddd.Recepcion.API.PerfilesDeConversion
{
    public class PerfilDeCliente: Profile
    {
        public PerfilDeCliente()
        {
            CreateMap<Cliente, ClienteDto>()
            .ForMember(dto => dto.ClienteId, options => options.MapFrom(src => src.Id));

            CreateMap<ClienteDto, Cliente>()
            .ForMember(src => src.Id, options => options.MapFrom(src => src.ClienteId));

            CreateMap<LlamadaCrearCliente, Cliente>();
        }
    }
}
