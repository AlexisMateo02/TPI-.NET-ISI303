using Academia.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class MateriaRepository
    {
        private readonly string _connectionString;

        public MateriaRepository()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public Materia? Get(int id)
        {
            Materia? materia = null;

            string query = @"
                SELECT m.IdMateria, m.DescripcionMateria, m.HorasSemanales, 
                       m.HorasTotales, m.IdPlan,
                       p.Descripcion as PlanDescripcion,
                       e.Id as EspecialidadId, e.Descripcion as EspecialidadDescripcion
                FROM Materias m
                INNER JOIN Planes p ON m.IdPlan = p.IdPlan
                INNER JOIN Especialidades e ON p.IdEspecialidad = e.Id
                WHERE m.IdMateria = @IdMateria";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMateria", id);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                materia = MapReaderToMateria(reader);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"Error al obtener materia: {ex.Message}", ex);
                    }
                }
            }

            return materia;
        }

        public IEnumerable<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();

            string query = @"
                SELECT m.IdMateria, m.DescripcionMateria, m.HorasSemanales, 
                       m.HorasTotales, m.IdPlan,
                       p.Descripcion as PlanDescripcion,
                       e.Id as EspecialidadId, e.Descripcion as EspecialidadDescripcion
                FROM Materias m
                INNER JOIN Planes p ON m.IdPlan = p.IdPlan
                INNER JOIN Especialidades e ON p.IdEspecialidad = e.Id
                ORDER BY m.IdMateria";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                materias.Add(MapReaderToMateria(reader));
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"Error al obtener materias: {ex.Message}", ex);
                    }
                }
            }

            return materias;
        }

        public void Add(Materia materia)
        {
            string query = @"
                INSERT INTO Materias (DescripcionMateria, HorasSemanales, HorasTotales, IdPlan)
                OUTPUT INSERTED.IdMateria
                VALUES (@DescripcionMateria, @HorasSemanales, @HorasTotales, @IdPlan)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DescripcionMateria", materia.DescripcionMateria);
                    command.Parameters.AddWithValue("@HorasSemanales", materia.HorasSemanales);
                    command.Parameters.AddWithValue("@HorasTotales", materia.HorasTotales);
                    command.Parameters.AddWithValue("@IdPlan", materia.IdPlan);

                    try
                    {
                        connection.Open();
                        int newId = (int)command.ExecuteScalar();
                        // Usar reflexión para establecer el ID (ya que es private set)
                        var idProperty = typeof(Materia).GetProperty("IdMateria");
                        idProperty?.SetValue(materia, newId);
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"Error al agregar materia: {ex.Message}", ex);
                    }
                }
            }
        }

        public bool Update(Materia materia)
        {
            string query = @"
                UPDATE Materias 
                SET DescripcionMateria = @DescripcionMateria,
                    HorasSemanales = @HorasSemanales,
                    HorasTotales = @HorasTotales,
                    IdPlan = @IdPlan
                WHERE IdMateria = @IdMateria";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMateria", materia.IdMateria);
                    command.Parameters.AddWithValue("@DescripcionMateria", materia.DescripcionMateria);
                    command.Parameters.AddWithValue("@HorasSemanales", materia.HorasSemanales);
                    command.Parameters.AddWithValue("@HorasTotales", materia.HorasTotales);
                    command.Parameters.AddWithValue("@IdPlan", materia.IdPlan);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"Error al actualizar materia: {ex.Message}", ex);
                    }
                }
            }
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Materias WHERE IdMateria = @IdMateria";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMateria", id);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"Error al eliminar materia: {ex.Message}", ex);
                    }
                }
            }
        }

        public int CountCursosByMateria(int idMateria)
        {
            string query = "SELECT COUNT(*) FROM Cursos WHERE IdMateria = @IdMateria";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMateria", idMateria);

                    try
                    {
                        connection.Open();
                        return (int)command.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"Error al contar cursos: {ex.Message}", ex);
                    }
                }
            }
        }

        public bool PlanAndDescripcionMateriaExist(int idPlan, string descripcionMateria, int? excludeId = null)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM Materias 
                WHERE LOWER(DescripcionMateria) = LOWER(@DescripcionMateria) 
                AND IdPlan = @IdPlan";

            if (excludeId.HasValue)
            {
                query += " AND IdMateria != @ExcludeId";
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DescripcionMateria", descripcionMateria);
                    command.Parameters.AddWithValue("@IdPlan", idPlan);

                    if (excludeId.HasValue)
                    {
                        command.Parameters.AddWithValue("@ExcludeId", excludeId.Value);
                    }

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"Error al verificar existencia: {ex.Message}", ex);
                    }
                }
            }
        }

        public bool PlanExists(int idPlan)
        {
            string query = "SELECT COUNT(*) FROM Planes WHERE IdPlan = @IdPlan";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdPlan", idPlan);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"Error al verificar plan: {ex.Message}", ex);
                    }
                }
            }
        }

        private Materia MapReaderToMateria(SqlDataReader reader)
        {
            int idMateria = reader.GetInt32(reader.GetOrdinal("IdMateria"));
            string descripcionMateria = reader.GetString(reader.GetOrdinal("DescripcionMateria"));
            int horasSemanales = reader.GetInt32(reader.GetOrdinal("HorasSemanales"));
            int horasTotales = reader.GetInt32(reader.GetOrdinal("HorasTotales"));
            int idPlan = reader.GetInt32(reader.GetOrdinal("IdPlan"));

            Materia materia = new Materia(idMateria, descripcionMateria, horasSemanales, horasTotales, idPlan);

            try
            {
                string planDescripcion = reader.GetString(reader.GetOrdinal("PlanDescripcion"));
                int especialidadId = reader.GetInt32(reader.GetOrdinal("EspecialidadId"));
                string especialidadDescripcion = reader.GetString(reader.GetOrdinal("EspecialidadDescripcion"));

                Especialidad especialidad = new Especialidad(especialidadId, especialidadDescripcion);

                Plan plan = new Plan(idPlan, planDescripcion, especialidadId);

                // Usar reflexión para asignar la Especialidad al Plan
                var planEspecialidadField = typeof(Plan).GetField("_especialidad",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                if (planEspecialidadField != null)
                {
                    planEspecialidadField.SetValue(plan, especialidad);
                }

                // Usar reflexión para asignar el Plan a la Materia
                var materiaPlanField = typeof(Materia).GetField("_plan",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                if (materiaPlanField != null)
                {
                    materiaPlanField.SetValue(materia, plan);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al mapear Plan/Especialidad: {ex.Message}");
            }

            return materia;
        }
    }
}