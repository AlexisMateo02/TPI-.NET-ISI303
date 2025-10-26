using DTOs;
using Services;

namespace APIWeb
{
    public static class DocenteCursoEndpoints
    {
        public static void MapDocenteCursoEndpoints(this WebApplication app)
        {
            app.MapGet("/docentecursos/{id}", (int id) =>
            {
                DocenteCursoService docenteCursoService = new DocenteCursoService();
                DocenteCursoDTO dto = docenteCursoService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetDocenteCurso")
            .Produces<DocenteCursoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/docentecursos", () =>
            {
                DocenteCursoService docenteCursoService = new DocenteCursoService();
                var dtos = docenteCursoService.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllDocenteCursos")
            .Produces<List<DocenteCursoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/docentecursos", (DocenteCursoDTO dto) =>
            {
                try
                {
                    DocenteCursoService docenteCursoService = new DocenteCursoService();
                    DocenteCursoDTO docenteCursoDTO = docenteCursoService.Add(dto);
                    return Results.Created($"/docentecursos/{docenteCursoDTO.IdDictado}", docenteCursoDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddDocenteCurso")
            .Produces<DocenteCursoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/docentecursos", (DocenteCursoDTO dto) =>
            {
                try
                {
                    DocenteCursoService docenteCursoService = new DocenteCursoService();
                    var found = docenteCursoService.Update(dto);

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
            .WithName("UpdateDocenteCurso")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/docentecursos/{id}", (int id) =>
            {
                try
                {
                    DocenteCursoService docenteCursoService = new DocenteCursoService();
                    var deleted = docenteCursoService.Delete(id);

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
            .WithName("DeleteDocenteCurso")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapGet("/docentecursos/existDocenteCurso", (int idDocente, int idCurso, int? excludeId) =>
            {
                try
                {
                    DocenteCursoService docenteCursoService = new DocenteCursoService();
                    bool exists = docenteCursoService.ExistsDocenteCurso(idDocente, idCurso, excludeId);
                    return Results.Ok(exists);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("ExistDocenteCursoInDocenteCurso")
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();
        }
    }
}
