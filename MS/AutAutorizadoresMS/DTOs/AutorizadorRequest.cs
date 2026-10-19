using System;
using System.ComponentModel.DataAnnotations;

namespace AutAutorizadoresMS.DTOs;

public class AutorizadorRequest
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [MaxLength(100)]    
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El email es obligatorio")]
    [MaxLength(100)]
    public string Email { get; set; }
      
    [StringLength(9, ErrorMessage = "El teléfono debe tener 9 dígitos")]
    public string? Telefono { get; set; }

    public AutorizadorRequest()
    {
        Nombre = string.Empty;
        Email = string.Empty;
        Telefono = null;
    }

}
