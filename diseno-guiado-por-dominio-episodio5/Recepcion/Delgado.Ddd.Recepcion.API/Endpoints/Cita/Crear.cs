using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Delgado.Ddd.KernellCompartido;
using Delgado.Ddd.KernellCompartido.Interfaces;
using Delgado.Ddd.Recepcion.Compartido.Modelos.Cita;
using Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario;
using Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario.Especificaciones;
using Delgado.Ddd.Recepcion.Dominio.AgregadosSincronizados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace Delgado.Ddd.Recepcion.API.Endpoints.Cita
{
    public class Crear: BaseAsyncEndpoint
        .WithRequest<LlamadaCrearCita>
        .WithResponse<RespuestaCrearCita>
    {
        private readonly IRepositorio<Calendario> _repositorioDeCalendario;
        private readonly IRepositorioDeLectura<TipoDeCita> _repositorioDeTipoDeCita;
        private readonly IMapper _mapper;
        private readonly ILogger<Crear> _logger;

        public Crear(IRepositorio<Calendario> repositorioDeCalendario, IRepositorioDeLectura<TipoDeCita> repositorioDeTipoDeCita, IMapper mapper, ILogger<Crear> logger)
        {
            _repositorioDeCalendario = repositorioDeCalendario;
            _repositorioDeTipoDeCita = repositorioDeTipoDeCita;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost(LlamadaCrearCita.Ruta)]
        [SwaggerOperation(
        Summary = "Crea una nueva cita",
        Description = "Crea una nueva cita",
        OperationId = "cita.crear",
        Tags = new[] { "CitasEndpoints" })
    ]
        public override async Task<ActionResult<RespuestaCrearCita>> HandleAsync(LlamadaCrearCita llamada, CancellationToken cancellationToken)
        {
            var respuesta = new RespuestaCrearCita(llamada.CorrelationId());

            var especificacion = new CalendarioPorIdConCitasEsp(llamada.CalendarioId); // TODO: seria mejor solo mostrar citas de ese dia
            var calendario = await _repositorioDeCalendario.GetBySpecAsync(especificacion);

            var tipodeCita = await _repositorioDeTipoDeCita.GetByIdAsync(llamada.TipoDeCitaId);
            var ComienzoDeCita = llamada.FechaDeCita;
            var rangoDeTiempo = new RangoDeFechaTiempo(ComienzoDeCita.Date, TimeSpan.FromMinutes(tipodeCita.Duracion));

            var nuevaCita = new Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario.Cita(Guid.NewGuid(), llamada.CalendarioId, llamada.ClienteId, llamada.PeluqueroId, llamada.TiendaId, llamada.TipoDeCitaId, rangoDeTiempo, new DateTimeOffset());

            calendario.AgregarCita(nuevaCita);

            await _repositorioDeCalendario.UpdateAsync(calendario);
            _logger.LogInformation($"Cita creada para clienteId: {llamada.ClienteId}, Id: {nuevaCita.Id}");

            var dto = _mapper.Map<CitaDto>(nuevaCita);
            _logger.LogInformation(dto.ToString());
            respuesta.Cita = dto;

            return Ok(respuesta);
        }
    }
}
