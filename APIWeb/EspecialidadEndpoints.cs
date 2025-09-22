using Services;
using DTOs;

namespace APIWeb
{
    public static class EspecialidadEndpoints
    {
        public static void MapEspecialidadEndpoints(this WebApplication app)
        {
            app.MapGet("/especialidades/{id}", (int id) =>
            {
                EspecialidadService especialidadService = new EspecialidadService();
                EspecialidadDTO dto = especialidadService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetEspecialidad")
            .Produces<EspecialidadDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/especialidades", () =>
            {
                EspecialidadService especialidadService = new EspecialidadService();

                var dtos = especialidadService.GetAll();

                return Results.Ok(dtos);
            })
            .WithName("GetAllEspecialidades")
            .Produces<List<EspecialidadDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/especialidades", (EspecialidadDTO dto) =>
            {
                try
                {
                    EspecialidadService especialidadService = new EspecialidadService();

                    EspecialidadDTO especialidadDTO = especialidadService.Add(dto);

                    return Results.Created($"/especialidades/{especialidadDTO.Id}", especialidadDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddEspecialidad")
            .Produces<EspecialidadDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/especialidades", (EspecialidadDTO dto) =>
            {
                try
                {
                    EspecialidadService especialidadService = new EspecialidadService();

                    var found = especialidadService.Update(dto);

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
            .WithName("UpdateEspecialidad")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/especialidades/{id}", (int id) =>
            {
                EspecialidadService especialidadService = new EspecialidadService();

                var deleted = especialidadService.Delete(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteEspecialidad")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
