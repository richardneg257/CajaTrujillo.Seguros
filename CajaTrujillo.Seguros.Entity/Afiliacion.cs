using System.ComponentModel.DataAnnotations;

namespace CajaTrujillo.Seguros.Entity;
public class Afiliacion
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string NumeroPoliza { get; set; }
    [Required]
    public DateTime FechaAfiliacion { get; set; }
    [Required]
    public DateTime FechaVigencia { get; set; }
    [Required]
    [StringLength(20)]
    public string Estado { get; set; }
    [Required]
    public int ClienteId { get; set; }
    [Required]
    public int SeguroId { get; set; }
    public Cliente Cliente { get; set; }
    public Seguro Seguro { get; set; }
    public List<Pago> Pagos { get; set; }
}
