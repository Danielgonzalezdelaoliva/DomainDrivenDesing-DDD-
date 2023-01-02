using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Delgado.Ddd.KernellCompartido.Interfaces;
using Delgado.Ddd.Recepcion.Compartido.Modelos.Cita;
using Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario;
using Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario.Especificaciones;
using Delgado.Ddd.Recepcion.Dominio.AgregadosSincronizados;
using Delgado.Ddd.Recepcion.Dominio.AgregadosSincronizados.Especificaciones.Clientes;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Delgado.Ddd.Recepcion.API.Endpoints.Cita
{
    public class BuscarPorId : BaseAsyncEndpoint
        .WithRequest<LlamadaBuscarCitaPorId>
        .WithResponse<RespuestaBuscarCitaPorId>
    {
        private readonly IRepositorioDeLectura<Calendario> _repositorioDeCalendario;
        private readonly IRepositorioDeLectura<Cliente> _repositorioDeCliente;
        private readonly IMapper _mapper;

        public BuscarPorId(IRepositorioDeLectura<Calendario> repositorioDeCalendario, IRepositorioDeLectura<Cliente> repositorioDeCliente, IMapper mapper)
        {
            _repositorioDeCalendario = repositorioDeCalendario;
            _repositorioDeCliente = repositorioDeCliente;
            _mapper = mapper;
        }

        [HttpGet(LlamadaBuscarCitaPorId.Ruta)]
        [SwaggerOperation(
        Summary = "Buscar cita por su Id",
        Description = "Buscar una cita por su Id",
        OperationId = "Cita.BuscarPorId",
        Tags = new[] { "CitasEndpoints" })
    ]
        public override async Task<ActionResult<RespuestaBuscarCitaPorId>> HandleAsync([FromRoute] LlamadaBuscarCitaPorId llamada, CancellationToken cancellationToken)
        {
            var respuesta = new RespuestaBuscarCitaPorId(llamada.CorrelationId());

            var especificacion = new CalendarioPorIdConCitasEsp(llamada.CalendarioId); // TODO: Seria mejor buscar citas por el dia actual
            var calendario = await _repositorioDeCalendario.GetBySpecAsync(especificacion);

            var cita = calendario.Citas.FirstOrDefault(a => a.Id == llamada.CitaId);
            if (cita == null) return NotFound();

            respuesta.Cita = _mapper.Map<CitaDto>(cita);

            // cargar nombres
            var especificacionDeCliente = new ClientePorIdEsp(cita.ClienteId);
            var cliente = await _repositorioDeCliente.GetBySpecAsync(especificacionDeCliente);
            
            respuesta.Cita.NombreDelCliente = cliente.NombreCompleto;            

            return Ok(respuesta);
        }
    }


}
