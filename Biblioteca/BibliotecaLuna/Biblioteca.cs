using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaLuna
{
    //Clase principal Biblioteca
    public class Biblioteca
    {
        //Creacion de lista de publicaciones y prestamos
        private List<Publicacion> publicaciones;
        private List<Prestamo> prestamos;
        private int siguienteIdPrestamo = 1;

        //Inicializa las listas de publicaciones y préstamos.
        public Biblioteca()
        {
            publicaciones = new List<Publicacion>();
            prestamos = new List<Prestamo>();
        }

        //Agregar publicaciones a la lista
        public void AgregarPublicacion(Publicacion publicacion)
        {
            publicaciones.Add(publicacion);
        }

        //Mostrar la informacion de cada elemento en la lista de publicaciones
        public void ListarPublicaciones()
        {
            foreach (var pub in publicaciones)
            {
                pub.MostrarInformacion();
            }
        }

        //Crear publicaciones estandar de la biblioteca
        public void CrearPublicaciones()
        {
            // Crear libros
            var libro1 = new Libro
            {
                Id = 1,
                Nombre = "El Imperio Final",
                Autor = "Brandon Sanderson",
                Editorial = "NOVA",
                AñoPublicacion = 2006,
                NumeroPaginas = 972,
                Idioma = "Español",
                Genero = "Fantasía Política"
            };

            var libro2 = new Libro
            {
                Id = 2,
                Nombre = "El Perfume",
                Autor = "Patrick Suskind",
                Editorial = "Sudamericana",
                AñoPublicacion = 1985,
                NumeroPaginas = 320,
                Idioma = "Español",
                Genero = "Misterio, ficción historica"
            };

            // Crear revistas
            var revista1 = new Revista
            {
                Id = 3,
                Nombre = "National Geographic",
                Autor = "National Geographic Society",
                Editorial = "National Geographic Partners",
                AñoPublicacion = 2024,
                NumeroEdicion = 145,
                Periodicidad = "Mensual",
                Categoria = "Ciencia y Naturaleza"
            };

            var revista2 = new Revista
            {
                Id = 4,
                Nombre = "Time Magazine",
                Autor = "Time USA LLC",
                Editorial = "Time Inc.",
                AñoPublicacion = 2024,
                NumeroEdicion = 52,
                Periodicidad = "Semanal",
                Categoria = "Noticias"
            };

            // Crear audiolibros
            var audio1 = new AudioLibro
            {
                Id = 5,
                Nombre = "El Principito",
                Autor = "Antoine de Saint-Exupéry",
                Editorial = "Audible",
                AñoPublicacion = 2023,
                DuracionMinutos = 90,
                Narrador = "Julia Jones",
                Idioma = "Español"
            };

            var audio2 = new AudioLibro
            {
                Id = 6,
                Nombre = "Atomic Habits",
                Autor = "James Clear",
                Editorial = "Random House Audio",
                AñoPublicacion = 2023,
                DuracionMinutos = 317,
                Narrador = "James Clear",
                Idioma = "Inglés"
            };

            AgregarPublicacion(libro1);
            AgregarPublicacion(libro2);
            AgregarPublicacion(revista1);
            AgregarPublicacion(revista2);
            AgregarPublicacion(audio1);
            AgregarPublicacion(audio2);
        }

        //Solicitar un prestamo
        public void SolicitarPrestamo()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("              ✧˖°. SOLICITAR PRÉSTAMO ✧˖°.");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine();

            // Mostrar publicaciones disponibles
            MostrarPublicacionesDisponibles();

            if (!HayPublicacionesDisponibles())
            {
                Console.WriteLine(" No hay publicaciones disponibles para préstamo. :(");
                return;
            }

            // Pedir datos al usuario
            Console.Write("Ingrese su nombre: ");
            string nombreUsuario = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                Console.WriteLine("Debe ingresar un nombre válido. :(");
                return;
            }

            Console.Write("Ingrese el ID de la publicación: ");
            if (!int.TryParse(Console.ReadLine(), out int idPublicacion))
            {
                Console.WriteLine(" ID no válido. :(");
                return;
            }

            // Procesar préstamo
            RealizarPrestamo(idPublicacion, nombreUsuario);
        }

        //Mostrar Publicaciones disponibles para el usuario

        private void MostrarPublicacionesDisponibles()
        {
            Console.WriteLine("PUBLICACIONES DISPONIBLES:");
            Console.WriteLine();

            bool hayDisponibles = false;
            foreach (var pub in publicaciones)
            {
                if (pub.Disponible)
                {
                    Console.WriteLine($"ID: {pub.Id} - {pub.Nombre} ({pub.GetType().Name})");
                    hayDisponibles = true;
                }
            }

            if (!hayDisponibles)
            {
                Console.WriteLine("No hay publicaciones disponibles.");
            }
            Console.WriteLine();
        }

        //Verificar si hay al menos una disponible
        private bool HayPublicacionesDisponibles()
        {
            foreach (var publicacion in publicaciones)
            {
                if (publicacion.Disponible)
                {
                    return true;
                }
            }
            return false;
        }

        //Realizar y consolidar prestamo solicitado
        private void RealizarPrestamo(int idPublicacion, string nombreUsuario)
        {
            // Buscar publicación
            var publicacion = publicaciones.FirstOrDefault(p => p.Id == idPublicacion);

            // Validaciones
            if (publicacion == null)
            {
                Console.WriteLine(" Publicación no encontrada. :(");
                return;
            }

            if (!publicacion.Disponible)
            {
                Console.WriteLine(" Esta publicación ya está prestada. :(");
                return;
            }

            // Crear préstamo
            var prestamo = new Prestamo
            {
                Id = siguienteIdPrestamo++,
                IdPublicacion = publicacion.Id,
                NombrePublicacion = publicacion.Nombre,
                TipoPublicacion = publicacion.GetType().Name,
                NombreUsuario = nombreUsuario,
                FechaPrestamo = DateTime.Now
            };

            // Actualizar estado
            publicacion.Disponible = false;
            prestamos.Add(prestamo);

            // Confirmar préstamo
            MostrarConfirmacionPrestamo(prestamo, publicacion);
        }

        //Confirmar prestamo con ayuda de la clase prestamo
        private void MostrarConfirmacionPrestamo(Prestamo prestamo, Publicacion publicacion)
        {
            Console.WriteLine();
            Console.WriteLine("¡PRÉSTAMO REALIZADO EXITOSAMENTE!");
            Console.WriteLine();
            prestamo.MostrarPrestamo();

            // Mostrar información específica según el tipo
            Console.WriteLine("INFORMACIÓN DE LA PUBLICACIÓN PRESTADA:");
            publicacion.MostrarInformacion();

            Console.WriteLine("POLÍTICAS DE PRÉSTAMO:");
            publicacion.DiasPrestamo();
            Console.WriteLine();
        }


        //Mostrar prestamos activos al usuario
        private void MostrarPrestamosActivos()
        {
            Console.WriteLine("PRÉSTAMOS ACTIVOS:");
            Console.WriteLine();

            var prestamosActivos = prestamos.Where(p => p.Activo).ToList();

            if (prestamosActivos.Count == 0)
            {
                Console.WriteLine("No hay préstamos activos.");
            }
            else
            {
                foreach (var prestamo in prestamosActivos)
                {
                    Console.WriteLine($"ID: {prestamo.Id} - {prestamo.NombrePublicacion} (Usuario: {prestamo.NombreUsuario})");
                }
            }
            Console.WriteLine();
        }

        //Verificar si hay prestamos activos
        private bool HayPrestamosActivos()
        {
            foreach (var prestamo in prestamos)
            {
                if (prestamo.Activo)
                {
                    return true;
                }
            }
            return false;
        }

        //Devolver publicacion
        public void DevolverPublicacion()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("              ✧˖°. DEVOLVER PUBLICACIÓN ✧˖°.");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine();

            if (!HayPrestamosActivos())
            {
                Console.WriteLine(" No hay préstamos activos.");
                return;
            }

            // Mostrar préstamos activos
            MostrarPrestamosActivos();

            Console.Write("Ingrese el ID del préstamo a devolver: ");
            if (!int.TryParse(Console.ReadLine(), out int idPrestamo))
            {
                Console.WriteLine(" ID no válido. :(");
                return;
            }

            ProcesarDevolucion(idPrestamo);
        }

        //Procesar devolucion 
        private void ProcesarDevolucion(int idPrestamo)
        {
            var prestamo = prestamos.FirstOrDefault(p => p.Id == idPrestamo && p.Activo);

            if (prestamo == null)
            {
                Console.WriteLine(" Préstamo no encontrado o ya devuelto.");
                return;
            }

            // Encontrar y actualizar publicación
            var publicacion = publicaciones.FirstOrDefault(p => p.Id == prestamo.IdPublicacion);
            if (publicacion != null)
            {
                publicacion.Disponible = true;
            }

            // Marcar préstamo como devuelto
            prestamo.Activo = false;

            Console.WriteLine();
            Console.WriteLine(" ¡DEVOLUCIÓN REALIZADA EXITOSAMENTE!");
            Console.WriteLine();
            Console.WriteLine($"La publicación '{prestamo.NombrePublicacion}' ha sido devuelta.");
            Console.WriteLine($"Ahora está disponible para otros usuarios.");
            Console.WriteLine();
        }

        //Ver el estado de todas las publicaciones en la biblioteca

        public void VerEstadoPublicaciones()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("            ✧˖°. ESTADO DE PUBLICACIONES ✧˖°.");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine();

            Console.WriteLine($" ESTADÍSTICAS:");
            Console.WriteLine($"   Total publicaciones: {publicaciones.Count}");
            Console.WriteLine($"   Disponibles: {publicaciones.Count(p => p.Disponible)}");
            Console.WriteLine($"   Prestadas: {publicaciones.Count(p => !p.Disponible)}");
            Console.WriteLine($"   Préstamos activos: {prestamos.Count(p => p.Activo)}");
            Console.WriteLine();

            Console.WriteLine("DETALLE POR PUBLICACIÓN:");
            foreach (var pub in publicaciones)
            {
                string estado = pub.Disponible ? " DISPONIBLE" : "PRESTADA";
                Console.WriteLine($"   {pub.Id}. {pub.Nombre} - {estado}");
            }
            Console.WriteLine();
        }


        //Mostrar la cantidad de dias que se puede prestar cada publicacion
        public void MostrarDíasPrestamo()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("              ✧˖°. Cantidad de días de prestamo ✧˖°.");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("Asegurate de tenerlo claro antes de seleccionar tu próxima lectura!:");
            Console.WriteLine();

            foreach (var pub in publicaciones)
            {
                Console.WriteLine($" - {pub.Nombre} ({pub.GetType().Name}):");
                pub.DiasPrestamo();
                Console.WriteLine();
            }
        }



    }
}