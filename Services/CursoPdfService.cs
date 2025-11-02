using Academia.Entidades;
using DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Numerics;

namespace Services
{
    public class CursoPdfService
    {
        public byte[] GenerarPdf(CursoDTO curso)
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
                    .Text($"CURSO: {curso.DescripcionMateria} - {curso.DescripcionComision} - {curso.AnioCalendario}")
                    .SemiBold().FontSize(18).FontColor(Colors.Blue.Darken3);

                    page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(column =>
                    {
                        column.Spacing(10);

                        // Línea separadora
                        column.Item().PaddingVertical(10).LineHorizontal(1).LineColor(Colors.Grey.Lighten1);

                        // Lista de materias
                        column.Item().Text("INTEGRANTES DEL CURSO")
                            .SemiBold().FontSize(16).FontColor(Colors.Blue.Darken2);

                        if (curso.AlumnosInscriptos != null && curso.AlumnosInscriptos.Any())
                        {
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(3);   // NombreCompletoPersona
                                    columns.RelativeColumn(3);  // Legajo
                                    columns.ConstantColumn(70);  // Nota
                                });

                                // Encabezado de la tabla
                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.Blue.Lighten3).Padding(5).Text("APELLIDO, NOMBRE").Bold().FontColor(Colors.White);
                                    header.Cell().Background(Colors.Blue.Lighten3).Padding(5).Text("LEGAJO").Bold().FontColor(Colors.White);
                                    header.Cell().Background(Colors.Blue.Lighten3).Padding(5).Text("NOTA").Bold().FontColor(Colors.White);
                                });

                                // Filas de alumnos
                                foreach (var alumno in curso.AlumnosInscriptos.OrderBy(m => m.ApellidoPersona))
                                {
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(alumno.NombreCompletoPersona);
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(alumno.Legajo.ToString());
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(alumno.Nota.ToString());
                                }
                            });

                            column.Item().PaddingTop(10).Text($"Total de alumnos: {curso.AlumnosInscriptos.Count}")
                                .SemiBold().FontSize(11);
                        }
                        else
                        {
                            column.Item().Text("No hay alumnos inscriptos a este curso.")
                                .Italic().FontColor(Colors.Grey.Medium);
                        }
                    });

                });
            });

            return document.GeneratePdf();
        }
    }
}
