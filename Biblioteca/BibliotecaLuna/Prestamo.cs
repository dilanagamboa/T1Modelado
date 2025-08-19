using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaLuna
{
    //Clase prestamo
    public class Prestamo
    {
        public int Id { get; set; }
        public int IdPublicacion { get; set; }
        public string NombrePublicacion { get; set; } = "";
        public string TipoPublicacion { get; set; } = "";
        public string NombreUsuario { get; set; } = "";
        public DateTime FechaPrestamo { get; set; }
        public bool Activo { get; set; } = true;

        //Mostrar la informacion del prestamo realizado
        public void MostrarPrestamo()
        {
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine($"  ✧˖°. PRÉSTAMO #{Id} ✧˖°.");
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine($"  Usuario ................... {NombreUsuario}");
            Console.WriteLine($"  Publicación ............... {NombrePublicacion}");
            Console.WriteLine($"  Tipo ...................... {TipoPublicacion}");
            Console.WriteLine($"  Fecha préstamo ............ {FechaPrestamo:dd/MM/yyyy}");
            Console.WriteLine($"  Estado .................... {(Activo ? "ACTIVO" : "DEVUELTO")}");
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine();
        }

    }
}