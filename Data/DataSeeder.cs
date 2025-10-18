using Academia.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public static class DataSeeder
    {
        public static void Seed(TPIContext context)
        {
            Console.WriteLine("Iniciando seeding de datos...");

            // Verificar si ya existe el usuario admin
            if (!context.Usuarios.Any(u => u.NombreUsuario == "admin"))
            {
                Console.WriteLine("Creando usuario admin...");

                var usuario = new Usuario(
                    nombreUsuario: "admin",
                    clave: "admin123",
                    fechaAlta: DateTime.Now,
                    rolUsuario: 1 // Admin
                );

                context.Usuarios.Add(usuario);

                try
                {
                    var cambios = context.SaveChanges();
                    Console.WriteLine($"Usuario admin creado exitosamente. Cambios: {cambios}");
                    Console.WriteLine($"Hash generado: {usuario.Clave}");
                    Console.WriteLine($"Salt generado: {usuario.Salt}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al guardar usuario admin: {ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                    }
                }
            }
            else
            {
                Console.WriteLine("El usuario admin ya existe en la base de datos");

                // Verificar los datos del usuario admin existente
                var admin = context.Usuarios.FirstOrDefault(u => u.NombreUsuario == "admin");
                if (admin != null)
                {
                    Console.WriteLine($"Datos del admin - Clave: {admin.Clave}, Salt: {admin.Salt}, Habilitado: {admin.Habilitado}");

                    // Probar si la contraseña es correcta
                    var esValida = admin.ValidateClave("admin123");
                    Console.WriteLine($"¿Contraseña 'admin123' es válida? {esValida}");
                }
            }

            Console.WriteLine("Seeding de datos completado.");
        }
    }
}