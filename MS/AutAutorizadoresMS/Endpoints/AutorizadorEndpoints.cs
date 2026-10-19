using AutAutorizadoresMS.Data;
using AutAutorizadoresMS.DTOs;
using Microsoft.EntityFrameworkCore;


namespace AutAutorizadoresMS.Endpoints;

public static class AutorizadorEndpoints
{
  public static void MapAutorizadorEndpoints(this IEndpointRouteBuilder endpoints)
  {
    var group = endpoints.MapGroup("/autorizador").WithTags("Autorizador");

    group.MapGet("/", async (AppDbContext db) =>
      {
        var autorizadores = await db.Autorizadores
              .Select(p => new AutorizadorResponse
              {
                Id = p.Id,
                Nombre = p.Nombre,
                Email = p.Email,
                Telefono = p.Telefono
              }).ToListAsync();

        return Results.Ok(autorizadores);
      });

    group.MapPost("/", async (AutorizadorRequest request, AppDbContext db) =>
      {
        var autorizador = new Models.Autorizador
        {
          Nombre = request.Nombre,
          Email = request.Email,
          Telefono = request.Telefono,
          NivelCargo = 1
        };

        db.Autorizadores.Add(autorizador);
        await db.SaveChangesAsync(); 

        var response = new AutorizadorResponse
        {
          Id = autorizador.Id, //se genera en await db.SaveChangesAsync();
          Nombre = autorizador.Nombre,
          Email = autorizador.Email,
          Telefono = autorizador.Telefono
        };

        return Results.Created($"/api/autorizadores/{autorizador.Id}", response);
      });

      group.MapPut("/{id:int}", async (int id, AutorizadorRequest request, AppDbContext db) =>
      {
        var autorizador = await db.Autorizadores.FindAsync(id);
        if (autorizador == null)
        {
          return Results.NotFound();
        }

        autorizador.Nombre = request.Nombre;
        autorizador.Email = request.Email;
        autorizador.Telefono = request.Telefono;

        await db.SaveChangesAsync();

        return Results.NoContent();
      });
  }
}