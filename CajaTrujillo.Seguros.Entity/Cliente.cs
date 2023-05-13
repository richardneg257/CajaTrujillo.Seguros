using System.ComponentModel.DataAnnotations;

namespace CajaTrujillo.Seguros.Entity;
public class Cliente
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(10)]
    public string Dni { get; set; }
    [Required]
    [StringLength(50)]
    public string Nombres { get; set; }
    [Required]
    [StringLength(50)]
    public string Apellidos { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public List<Afiliacion> Afiliaciones { get; set; }
}
