using System.ComponentModel.DataAnnotations;

namespace CajaTrujillo.Seguros.Entity;
public class Seguro
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Compania { get; set; }
    [Required]
    [StringLength(20)]
    public string TipoSeguro { get; set; }
    [Required]
    public decimal FactorImpuesto { get; set; }
    [Required]
    public decimal PorcentajeComision { get; set; }
    [Required]
    public decimal MontoPrima { get; set; }
    [Required]
    [StringLength(20)]
    public string Moneda { get; set; }
    [Required]
    public int EdadMaxima { get; set; }
    [Required]
    public decimal ImporteMensual { get; set; }
    [Required]
    [StringLength(50)]
    public string Cobertura { get; set; }

    public List<Afiliacion> Afiliaciones { get; set; }
}
