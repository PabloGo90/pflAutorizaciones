using System.ComponentModel.DataAnnotations;

namespace AutAutorizadoresMS.Models;

public class Autorizador
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; }
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
    public string? Telefono { get; set; }
    public int NivelCargo { get; set; }

    public Autorizador()
    {
        Nombre = string.Empty;
        Email = string.Empty;
        Telefono = null;
        NivelCargo = 0;
    }
}