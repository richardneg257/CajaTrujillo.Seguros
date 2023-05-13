namespace CajaTrujillo.Seguros.Service.Dtos;
public class RespuestaAfiliacionDto
{
    public int Estado { get; set; }
    public string Mensaje { get; set; }
    public CreacionAfiliacionDto Datos { get; set; }
}
