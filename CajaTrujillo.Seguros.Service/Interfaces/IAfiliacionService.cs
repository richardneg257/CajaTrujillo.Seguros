using CajaTrujillo.Seguros.Service.Dtos;

namespace CajaTrujillo.Seguros.Service.Interfaces;
public interface IAfiliacionService
{
    Task<RespuestaAfiliacionDto> Afiliar(CreacionAfiliacionDto crearAfiliacionDto);
}
