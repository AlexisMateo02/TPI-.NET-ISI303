using DTOs;
using Services;

namespace APIWeb
{
    public static class AlumnoInscripcionEndpoints
    {
        public static void MapAlumnoInscripcionEndpoints(this WebApplication app)
        {
            app.MapGet("/alumnoinscripciones/{id}", (int id) =>
            {
                AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();
                AlumnoInscripcionDTO dto = alumnoInscripcionService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetAlumnoInscripcion")
            .Produces<AlumnoInscripcionDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/alumnoinscripciones", () =>
            {
                AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();
                var dtos = alumnoInscripcionService.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllAlumnoInscripciones")
            .Produces<List<AlumnoInscripcionDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/alumnoinscripciones", (AlumnoInscripcionDTO dto) =>
            {
                try
                {
                    AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();
                    AlumnoInscripcionDTO alumnoInscripcionDTO = alumnoInscripcionService.Add(dto);
                    return Results.Created($"/alumnoinscripciones/{alumnoInscripcionDTO.IdInscripcion}", alumnoInscripcionDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddAlumnoInscripcion")
            .Produces<AlumnoInscripcionDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/alumnoinscripciones", (AlumnoInscripcionDTO dto) =>
            {
                try
                {
                    AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();
                    var found = alumnoInscripcionService.Update(dto);

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
            .WithName("UpdateAlumnoInscripcion")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/alumnoinscripciones/{id}", (int id) =>
            {
                try
                {
                    AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();
                    var deleted = alumnoInscripcionService.Delete(id);

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
            .WithName("DeleteAlumnoInscripcion")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapGet("/alumnoinscripciones/existAlumnoCurso", (int idAlumno, int idCurso, int? excludeId) =>
            {
                try
                {
                    AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();
                    bool exists = alumnoInscripcionService.ExistsAlumnoCurso(idAlumno, idCurso, excludeId);
                    return Results.Ok(exists);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("ExistAlumnoCursoInAlumnoInscripcion")
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();
        }
    }
}
