using CajaTrujillo.Seguros.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CajaTrujillo.Seguros.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PagosController : ControllerBase
{
    private readonly IPagosService _pagosService;

    public PagosController(IPagosService pagosService)
    {
        _pagosService = pagosService;
    }

    [HttpPost]
    public async Task<ActionResult> Pagar([FromQuery] string dni)
    {
        await _pagosService.Pagar(dni);
        return Ok();
    }
}
