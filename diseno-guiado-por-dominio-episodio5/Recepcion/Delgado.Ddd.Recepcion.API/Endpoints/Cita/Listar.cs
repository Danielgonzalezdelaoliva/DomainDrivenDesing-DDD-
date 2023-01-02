using System;
using System.Collections.Generic;
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
using Delgado.Ddd.Recepcion.Dominio.Excepciones;
using Delgado.Ddd.Recepcion.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace Delgado.Ddd.Recepcion.API.Endpoints.Cita
{
    public class Listar : BaseAsyncEndpoint
        .WithRequest<LlamadaListarCitas>
        .WithResponse<RespuestaListarCitas>
    {
        private readonly IRepositorioDeLectura<Calendario> _repositorioDeCalendario;
        private readonly IRepositorioDeLectura<Cliente> _repositorioDeCliente;
        private readonly IMapper _mapper;
        private readonly IConfiguracionDeAplicacion _configuracionDeAplicacion;
        private readonly ILogger<Listar> _logger;

        public Listar(IRepositorioDeLectura<Calendario> repositorioDeCalendario, IRepositorioDeLectura<Cliente> repositorioDeCliente, IMapper mapper, IConfiguracionDeAplicacion settings, ILogger<Listar> logger)
        {
            _repositorioDeCalendario = repositorioDeCalendario;
            _repositorioDeCliente = repositorioDeCliente;
            _mapper = mapper;
            _configuracionDeAplicacion = settings;
            _logger = logger;
        }

        [HttpGet(LlamadaListarCitas.Ruta)]
        [SwaggerOperation(
        Summary = "Listar Citas",
        Description = "Listar Citas",
        OperationId = "citas.Listar",
        Tags = new[] { "CitaEndpoints" })
    ]
        public override async Task<ActionResult<RespuestaListarCitas>> HandleAsync([FromRoute] LlamadaListarCitas llamada, CancellationToken cancellationToken)
        {
            var respuesta = new RespuestaListarCitas(llamada.CorrelationId());
            Calendario calendario = null;
            if (llamada.CalendarioId == Guid.Empty)
            {
                return NotFound();
            }

            
            var especificacion = new CalendarioPorIdConCitasEsp(llamada.CalendarioId);
            calendario = await _repositorioDeCalendario.GetBySpecAsync(especificacion);
            if (calendario == null) throw new ExcepcionCalendarioNoEncontrado($"NO se encontro el calendario con Id: {llamada.CalendarioId}.");

            int totalDelCitasConflictivas = calendario.Citas.Count(a => a.HayPosibleConflicto);
            _logger.LogInformation($"API:ListarCitas Existen {totalDelCitasConflictivas} citas conflictivas.");

            var misCitas = _mapper.Map<List<CitaDto>>(calendario.Citas);

            //mejorarar esta parte para evitar n+1
            foreach (var c in misCitas)
            {
                var especificacionDeCliente = new ClientePorIdEsp(c.ClienteId);
                var cliente = await _repositorioDeCliente.GetBySpecAsync(especificacionDeCliente);
                
                c.NombreDelCliente = cliente.NombreCompleto;                
            }
            respuesta.Citas = misCitas.OrderBy(x => x.Comienzo).ToList();
            respuesta.CantidadDeRegistros = respuesta.Citas.Count();

            return Ok(respuesta);
        }

    }
}
