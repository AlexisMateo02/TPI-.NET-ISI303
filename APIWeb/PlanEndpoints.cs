using Services;
using DTOs;

namespace APIWeb
{
    public static class PlanEndpoints
    {
        public static void MapPlanEndpoints(this WebApplication app)
        {
            app.MapGet("/planes/{id}", (int id) =>
            {
                PlanService planService = new PlanService();
                PlanDTO dto = planService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetPlan")
            .Produces<PlanDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/planes", () =>
            {
                PlanService planService = new PlanService();

                var dtos = planService.GetAll();

                return Results.Ok(dtos);
            })
            .WithName("GetAllPlanes")
            .Produces<List<PlanDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/planes", (PlanDTO dto) =>
            {
                try
                {
                    PlanService planService = new PlanService();

                    PlanDTO planDTO = planService.Add(dto);

                    return Results.Created($"/planes/{planDTO.IdPlan}", planDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddPlan")
            .Produces<PlanDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/planes", (PlanDTO dto) =>
            {
                try
                {
                    PlanService planService = new PlanService();

                    var found = planService.Update(dto);

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
            .WithName("UpdatePlan")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/planes/{id}", (int id) =>
            {
                PlanService planService = new PlanService();

                var deleted = planService.Delete(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeletePlan")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            // Endpoint para validación desde Forms
            app.MapGet("/planes/existsDescripcion", (string descripcion, int idEspecialidad, int? excludeId) =>
            {
                try
                {
                    PlanService planService = new PlanService();
                    bool exists = planService.ExistsDescripcionInEspecialidad(descripcion, idEspecialidad, excludeId);
                    return Results.Ok(exists);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("ExistsDescripcionPlan")
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();
        }
    }
}
