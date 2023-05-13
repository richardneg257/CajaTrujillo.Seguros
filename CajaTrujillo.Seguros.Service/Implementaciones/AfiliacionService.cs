using CajaTrujillo.Seguros.Entity;
using CajaTrujillo.Seguros.Repository.Helpers;
using CajaTrujillo.Seguros.Repository.Interfaces;
using CajaTrujillo.Seguros.Service.Dtos;
using CajaTrujillo.Seguros.Service.Interfaces;

namespace CajaTrujillo.Seguros.Service.Implementaciones;
public class AfiliacionService : IAfiliacionService
{
    private readonly IAfiliacionRepository _afiliacionRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly ISeguroRepository _seguroRepository;

    public AfiliacionService(IAfiliacionRepository afiliacionRepository, IClienteRepository clienteRepository, ISeguroRepository seguroRepository)
    {
        _afiliacionRepository = afiliacionRepository;
        _clienteRepository = clienteRepository;
        _seguroRepository = seguroRepository;
    }

    public async Task<RespuestaAfiliacionDto> Afiliar(CreacionAfiliacionDto crearAfiliacionDto)
    {
        var clienteEntity = await _clienteRepository.ObtenerPorDniOPorApellidos(crearAfiliacionDto.Dni, crearAfiliacionDto.Apellidos);
        if(clienteEntity == null)
        {
            return new RespuestaAfiliacionDto()
            {
                Estado = 404,
                Mensaje = "El Cliente no fue encontrado."
            };
        }

        var seguroEntity = await _seguroRepository.ObtenerSeguroPorTipo(crearAfiliacionDto.TipoSeguro);
        if(seguroEntity == null)
        {
            return new RespuestaAfiliacionDto()
            {
                Estado = 404,
                Mensaje = "El Seguro no fue encontrado."
            };
        }

        // Validación de Edad Máxima
        var edadCliente = Helpers.CalcularEdad(clienteEntity.FechaNacimiento);
        if(edadCliente > seguroEntity.EdadMaxima)
        {
            return new RespuestaAfiliacionDto()
            {
                Estado = 400,
                Mensaje = "Error en la validación de la edad máxima del cliente."
            };
        }

        var afiliacionEntity = new Afiliacion()
        {
            NumeroPoliza = Helpers.CrearStringAleatorio(10),
            FechaAfiliacion = DateTime.Now,
            FechaVigencia = DateTime.Now.AddYears(2),
            Estado = "ACTIVO",
            ClienteId = clienteEntity.Id,
            SeguroId = seguroEntity.Id
        };

        await _afiliacionRepository.Afiliar(afiliacionEntity);

        return new RespuestaAfiliacionDto()
        {
            Estado = 201,
            Mensaje = "La afiliación se generó correctamente.",
            Datos = new CreacionAfiliacionDto()
            {
                Dni = clienteEntity.Dni,
                Apellidos = clienteEntity.Apellidos,
                TipoSeguro = seguroEntity.TipoSeguro
            }
        };
    }
}
