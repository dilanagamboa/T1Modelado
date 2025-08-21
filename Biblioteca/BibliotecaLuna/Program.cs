using System;

namespace BibliotecaLuna
{
    class Program
    {
        //Metodo principal 
        static void Main(string[] args)
        {
            var biblioteca = new Biblioteca();

            Console.WriteLine("Eres un: 1. Estudiante  2. Profesor");
            string tipoUsuario = Console.ReadLine() ?? "";
            Console.WriteLine("Ingresa tu nombre:");
            string nombreUsuario = Console.ReadLine() ?? "";
            var usuario = new Usuarios(tipoUsuario, nombreUsuario);
            
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("           ✧˖°. BIBLIOTECA LUNA ✧˖°.");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine();

            // Crear publicaciones automáticamente
            biblioteca.CrearPublicaciones();

            // Menú principal

            bool continuar = true;
            while (continuar)
            {   
                MostrarMenu();
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        TryClearConsole();
                        biblioteca.ListarPublicaciones();
                        break;

                    case "2":
                        TryClearConsole();
                        biblioteca.MostrarDíasPrestamo();
                        break;

                    case "3":
                        TryClearConsole();
                        biblioteca.SolicitarPrestamo();
                        break;

                    case "4":
                        TryClearConsole();
                        if (usuario.TipoUsuario == "2") // Solo profesor
                        {
                            TryClearConsole();
                            biblioteca.DevolverPublicacion();
                        }
                        else
                        {
                            Console.WriteLine("Opción no válida.");
                        }
                        break;

                    case "5":
                        TryClearConsole();
                        biblioteca.VerEstadoPublicaciones();
                        break;

                    case "6":
                        continuar = false;
                        Console.WriteLine("¡Hasta pronto!");
                        break;

                    default:
                        Console.WriteLine(" Opción no válida");
                        break;
                }

                // Crear la opcion de continuar en el menu al tocar la tecla enter
                if (continuar)
                {
                    Console.WriteLine("Presiona ENTER para continuar...");
                    Console.ReadLine();
                    TryClearConsole();
                }
            }
        }
        static void TryClearConsole()
        {
            try
            {
                Console.Clear();
            }
            catch (Exception ex)
            {
                
            }
        }
        //Mostrar el menu en consola
        static void MostrarMenu()
        {
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine("                    ✧˖°. MENÚ ✧˖°.");
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine("1. Ver catálogo completo");
            Console.WriteLine("2. Mostrar cantidad de días de prestamo");
            Console.WriteLine("3. Solicitar préstamo");
            Console.WriteLine("4. Devolver publicación");
            Console.WriteLine("5. Ver estado de publicaciones");
            Console.WriteLine("6. Salir");
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.Write("Seleccione una opción: ");
        }
    }
}

