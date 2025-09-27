using Services;
using DTOs;

namespace APIWeb
{
    public static class PersonaEndpoints
    {
        public static void MapPersonaEndpoints(this WebApplication app)
        {
            app.MapGet("/personas/{id}", (int id) =>
            {
                PersonaService personaService = new PersonaService();
                PersonaDTO dto = personaService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetPersona")
            .Produces<PersonaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/personas", () =>
            {
                PersonaService personaService = new PersonaService();
                var dtos = personaService.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllPersonas")
            .Produces<List<PersonaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/personas", (PersonaDTO dto) =>
            {
                try
                {
                    PersonaService personaService = new PersonaService();
                    PersonaDTO personaDTO = personaService.Add(dto);
                    return Results.Created($"/personas/{personaDTO.IdPersona}", personaDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddPersona")
            .Produces<PersonaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/personas", (PersonaDTO dto) =>
            {
                try
                {
                    PersonaService personaService = new PersonaService();
                    var found = personaService.Update(dto);

                    if (!found)
                    {
                        return Results.NotFound();
                    }

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdatePersona")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/personas/{id}", (int id) =>
            {
                try
                {
                    PersonaService personaService = new PersonaService();
                    var deleted = personaService.Delete(id);

                    if (!deleted)
                    {
                        return Results.NotFound();
                    }

                    return Results.NoContent();
                }
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("DeletePersona")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapGet("/personas/existsEmail", (string email, int? excludeId) =>
            {
                try
                {
                    PersonaService personaService = new PersonaService();
                    bool exists = personaService.ExistsEmail(email, excludeId);
                    return Results.Ok(exists);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("ExistsEmailPersona")
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapGet("/personas/existsLegajo", (int legajo, int? excludeId) =>
            {
                try
                {
                    PersonaService personaService = new PersonaService();
                    bool exists = personaService.ExistsLegajo(legajo, excludeId);
                    return Results.Ok(exists);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("ExistsLegajoPersona")
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapGet("/personas/alumnos", () =>
            {
                PersonaService personaService = new PersonaService();
                var dtos = personaService.GetAlumnos();
                return Results.Ok(dtos);
            })
            .WithName("GetAlumnos")
            .Produces<List<PersonaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/personas/docentes", () =>
            {
                PersonaService personaService = new PersonaService();
                var dtos = personaService.GetDocentes();
                return Results.Ok(dtos);
            })
            .WithName("GetDocentes")
            .Produces<List<PersonaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
        }
    }
}
