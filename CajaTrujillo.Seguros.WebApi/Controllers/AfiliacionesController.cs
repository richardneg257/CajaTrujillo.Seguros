using CajaTrujillo.Seguros.Service.Dtos;
using CajaTrujillo.Seguros.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CajaTrujillo.Seguros.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AfiliacionesController : ControllerBase
{
    private readonly IAfiliacionService _afiliacionService;

    public AfiliacionesController(IAfiliacionService afiliacionService)
    {
        _afiliacionService = afiliacionService;
    }

    [HttpPost]
    public async Task<ActionResult<RespuestaAfiliacionDto>> Afiliar([FromBody] CreacionAfiliacionDto crearAfiliacionDto)
    {
        var respuesta = await _afiliacionService.Afiliar(crearAfiliacionDto);

        if (respuesta.Estado == StatusCodes.Status404NotFound) return NotFound(respuesta);
        if (respuesta.Estado == StatusCodes.Status400BadRequest) return BadRequest(respuesta);

        return respuesta;
    }
}
