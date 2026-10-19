using System;

namespace AutAutorizadoresMS.DTOs;

public class AutorizadorResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string? Telefono { get; set; }

    public AutorizadorResponse()
    {
        Nombre = string.Empty;
        Email = string.Empty;
        Telefono = null;
    }
}
