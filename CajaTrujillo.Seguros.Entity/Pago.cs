using System.ComponentModel.DataAnnotations;

namespace CajaTrujillo.Seguros.Entity;
public class Pago
{
    [Key]
    public int Id { get; set; }
    public int Anio { get; set; }
    public int Mes { get; set; }
    public int AfiliacionId { get; set; }
    public Afiliacion Afiliacion { get; set; }
}
