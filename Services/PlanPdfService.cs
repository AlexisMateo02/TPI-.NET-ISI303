using DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Services
{
    public class PlanPdfService
    {
        public byte[] GenerarPdf(PlanDTO plan)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header()
                        .AlignCenter()
                        .Text($"PLAN DE ESTUDIO: {plan.Descripcion}")
                        .SemiBold().FontSize(18).FontColor(Colors.Blue.Darken3);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(column =>
                        {
                            column.Spacing(15);

                            // Información básica del plan
                            column.Item().Text($"Descripción: {plan.Descripcion}");

                            if (!string.IsNullOrEmpty(plan.DescripcionEspecialidad))
                            {
                                column.Item().Text($"Especialidad: {plan.DescripcionEspecialidad}");
                            }

                            // Línea separadora
                            column.Item().PaddingVertical(10).LineHorizontal(1).LineColor(Colors.Grey.Lighten1);

                            // Lista de materias
                            column.Item().Text("MATERIAS DEL PLAN")
                                .SemiBold().FontSize(16).FontColor(Colors.Blue.Darken2);

                            if (plan.Materias != null && plan.Materias.Any())
                            {
                                column.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.ConstantColumn(40);  // ID
                                        columns.RelativeColumn(3);   // Materia
                                        columns.ConstantColumn(70);  // Hs. Semanales
                                        columns.ConstantColumn(70);  // Hs. Totales
                                    });

                                    // Encabezado de la tabla
                                    table.Header(header =>
                                    {
                                        header.Cell().Background(Colors.Blue.Lighten3).Padding(5).Text("ID").Bold().FontColor(Colors.White);
                                        header.Cell().Background(Colors.Blue.Lighten3).Padding(5).Text("MATERIA").Bold().FontColor(Colors.White);
                                        header.Cell().Background(Colors.Blue.Lighten3).Padding(5).Text("HS. SEM").Bold().FontColor(Colors.White);
                                        header.Cell().Background(Colors.Blue.Lighten3).Padding(5).Text("HS. TOTAL").Bold().FontColor(Colors.White);
                                    });

                                    // Filas de materias
                                    foreach (var materia in plan.Materias.OrderBy(m => m.DescripcionMateria))
                                    {
                                        table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(materia.IdMateria.ToString());
                                        table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(materia.DescripcionMateria);
                                        table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(materia.HorasSemanales.ToString());
                                        table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(materia.HorasTotales.ToString());
                                    }

                                    // Totales
                                    var totalHsSemanales = plan.Materias.Sum(m => m.HorasSemanales);
                                    var totalHsTotales = plan.Materias.Sum(m => m.HorasTotales);

                                    table.Cell().Background(Colors.Grey.Lighten4).Padding(5).Text("").Bold();
                                    table.Cell().Background(Colors.Grey.Lighten4).Padding(5).Text("TOTALES").Bold();
                                    table.Cell().Background(Colors.Grey.Lighten4).Padding(5).Text(totalHsSemanales.ToString()).Bold();
                                    table.Cell().Background(Colors.Grey.Lighten4).Padding(5).Text(totalHsTotales.ToString()).Bold();
                                });

                                column.Item().PaddingTop(10).Text($"Total de materias: {plan.Materias.Count}")
                                    .SemiBold().FontSize(11);
                            }
                            else
                            {
                                column.Item().Text("No hay materias asignadas a este plan.")
                                    .Italic().FontColor(Colors.Grey.Medium);
                            }
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Generado el: ");
                            x.Span($"{DateTime.Now:dd/MM/yyyy HH:mm}");
                        });
                });
            });

            return document.GeneratePdf();
        }
    }
}