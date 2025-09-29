using DTOs;
using Services;

namespace APIWeb
{
    public static class CursoEndpoints
    {
        public static void MapCursoEndpoints(this WebApplication app)
        {
            app.MapGet("/cursos/{id}", (int id) =>
            {
                CursoService cursoService = new CursoService();
                CursoDTO dto = cursoService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetCurso")
            .Produces<CursoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/cursos", () =>
            {
                CursoService cursoService = new CursoService();
                var dtos = cursoService.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllCursos")
            .Produces<List<CursoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/cursos", (CursoDTO dto) =>
            {
                try
                {
                    CursoService cursoService = new CursoService();
                    CursoDTO cursoDTO = cursoService.Add(dto);
                    return Results.Created($"/cursos/{cursoDTO.IdCurso}", cursoDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddCurso")
            .Produces<CursoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/cursos", (CursoDTO dto) =>
            {
                try
                {
                    CursoService cursoService = new CursoService();
                    var found = cursoService.Update(dto);

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
            .WithName("UpdateCurso")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/cursos/{id}", (int id) =>
            {
                try
                {
                    CursoService cursoService = new CursoService();
                    var deleted = cursoService.Delete(id);

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
            .WithName("DeleteCurso")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapGet("/cursos/existComisionMateriaAndAnioCalendario", (int idComision, int idMateria, int anioCalendario, int? excludeId) =>
            {
                try
                {
                    CursoService cursoService = new CursoService();
                    bool exists = cursoService.ExistComisionMateriaAndAnioCalendario(idComision, idMateria, anioCalendario, excludeId);
                    return Results.Ok(exists);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("ExistComisionMateriaAndAnioCalendarioInCurso")
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();
        }

    }
}
