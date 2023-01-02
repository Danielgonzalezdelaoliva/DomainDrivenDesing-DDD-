using System;
using System.Threading.Tasks;
using Delgado.Ddd.Recepcion.Dominio.AgregadosSincronizados;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Delgado.Ddd.KernellCompartido;
using Delgado.Ddd.Recepcion.Dominio.AgregadosParaCalendario;
using System.Collections.Generic;
using System.Text.Json;
using Delgado.Ddd.Recepcion.Compartido.Modelos.TipoDeCita;
using System.IO;
using System.Linq;

namespace Delgado.Ddd.Recepcion.Infraestructura.Datos
{
    public class AppDbContextDatos
    {
        private readonly Guid _calendarioId = Guid.Parse("cb8e7dc0-31b3-4388-8c54-c66da208a678");
        private readonly int _tiendaId = 1;
        private DateTime _fechaDePrueba = DateTime.UtcNow.Date;
        private readonly AppDbContext _context;
        private readonly ILogger<AppDbContextDatos> _logger;
        private Cliente _clienteJuan = new Cliente("Juan Apellido","correo@gmail.com","555-555-5555", 1);
        private Cliente _clienteJose = new Cliente("Jose Apellido", "correo2@gmail.com", "777-777-7777", 1);

        public async Task LlenarDatosAsync(DateTime fechaDePrueba, int? tratarDeNuevo = 0)
        {
            _logger.LogInformation($"Llenando datos - fecha de prueba: {fechaDePrueba}");
            _logger.LogInformation($"DbContext Type: {_context.Database.ProviderName}");

            _fechaDePrueba = fechaDePrueba;
            int tratarDeNuevoParaDisponibilidad = tratarDeNuevo.Value;

            try
            {
                if (_context.EsBaseDeDatosReal())
                {
                    // apply migrations if connecting to a SQL database
                    _context.Database.Migrate();
                }

                if (!await _context.Calendarios.AnyAsync())
                {
                    await _context.Calendarios.AddAsync(
                        CrearCalendario());

                    await _context.SaveChangesAsync();
                }

                if (!await _context.TiposDeCita.AnyAsync())
                {
                    var apptTypes = await CrearTiposDeCitaAsync();
                    await _context.TiposDeCita.AddRangeAsync(apptTypes);
                    await _context.SalvarCambiosConIdentityInsert<TipoDeCita>();
                }

                if (!await _context.Clientes.AnyAsync())
                {
                    await _context.Clientes.AddRangeAsync(
                        CrearListaDeClientes());

                    await _context.SaveChangesAsync();
                }

                if (!await _context.Citas.AnyAsync())
                {
                    await _context.Citas.AddRangeAsync(CrearCitas(_calendarioId));

                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                if (tratarDeNuevoParaDisponibilidad < 1)
                {
                    tratarDeNuevoParaDisponibilidad++;
                    _logger.LogError(ex.Message);
                    await LlenarDatosAsync(_fechaDePrueba, tratarDeNuevoParaDisponibilidad);
                }
                throw;
            }

            await _context.SaveChangesAsync();
        }

        private Calendario CrearCalendario()
        {
            return new Calendario(_calendarioId, new RangoDeFechaTiempo(_fechaDePrueba, _fechaDePrueba), _tiendaId);
        }

        private async Task<List<TipoDeCita>> CrearTiposDeCitaAsync()
        {
            string fileName = "appointmentTypes.json";
            if (!File.Exists(fileName))
            {
                _logger.LogInformation($"Creating {fileName}");
                using Stream writer = new FileStream(fileName, FileMode.OpenOrCreate);
                await JsonSerializer.SerializeAsync(writer, ConseguirTiposDeCita());
            }

            _logger.LogInformation($"Leyendo tipos de cita del archivo: {fileName}");
            using Stream reader = new FileStream(fileName, FileMode.Open);
            var apptTypes = await JsonSerializer.DeserializeAsync<List<TipoDeCitaDto>>(reader);

            return apptTypes.Select(dto => new TipoDeCita(dto.TipoCitaId, dto.Nombre, dto.Duracion)).ToList();
        }

        private List<TipoDeCitaDto> ConseguirTiposDeCita()
        {
            var result = new List<TipoDeCitaDto>
            {
                new TipoDeCitaDto {
                  Nombre = "Corte De Cabello",
                   Duracion = 30,
                    TipoCitaId = 1                  
                },
                new TipoDeCitaDto {
                  Nombre = "Labado De Cabello",
                   Duracion = 10,
                    TipoCitaId = 2
                },
                new TipoDeCitaDto {
                  Nombre = "Corte De Barba y Bigote",
                   Duracion = 10,
                    TipoCitaId = 3
                },

            };

            return result;
        }

        private IEnumerable<Cliente> CrearListaDeClientes()
        {
            var clientes = new List<Cliente>();
            clientes.Add(_clienteJuan);
            clientes.Add(_clienteJose);
            return clientes;
        }

        private IEnumerable<Cita> CrearCitas(Guid calendarioId)
        {
            var corteDeCabello = 1;
            var listaDeCitas = new List<Cita>();
            listaDeCitas.Add(new Cita(Guid.NewGuid(), calendarioId, _clienteJuan.Id, _clienteJuan.PeluqueroFavoritoId, _tiendaId, corteDeCabello, new RangoDeFechaTiempo(_fechaDePrueba.AddHours(10).AddMinutes(30), TimeSpan.FromMinutes(30)), new DateTimeOffset(_fechaDePrueba.Date)));
            listaDeCitas.Add(new Cita(Guid.NewGuid(), calendarioId, _clienteJose.Id, _clienteJose.PeluqueroFavoritoId, _tiendaId, corteDeCabello, new RangoDeFechaTiempo(_fechaDePrueba.AddHours(11), TimeSpan.FromMinutes(30)), new DateTimeOffset(_fechaDePrueba.Date)));

            return listaDeCitas;
        }
    }
}
