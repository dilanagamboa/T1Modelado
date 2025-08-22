using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaLuna
{
    //Clase principal
    public class Entidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";

    }

    public abstract class Publicacion : Entidad
    {
        public string Autor { get; set; } = "";
        public int AñoPublicacion { get; set; }

        public bool Disponible { get; set; } = true;

        public string Editorial { get; set; } = "";

        //Metodo abstracto para mostrar la informacion de cada publicacion
        public abstract void MostrarInformacion();

        //Metodo abstracto para mostrar el tiempo que se ude prestar cada publicacion
        public virtual void DiasPrestamo()
        {
            Console.WriteLine(" ✧˖° La publicación se puede prestar por un máximo de 1 mes ");
        }
    }

    // Clases hija de publicacion

    //CLASE LIBRO
    public class Libro : Publicacion
    {
        public int NumeroPaginas { get; set; }
        public string Idioma { get; set; } = "";
        public string Genero { get; set; } = "";

        //Mostrar la informacion del libro
        public override void MostrarInformacion()
        {
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine($"  ✧˖°. LIBRO: {Nombre} ✧˖°.");
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine($"  Autor ..................... {Autor}");
            Console.WriteLine($"  Editorial ................. {Editorial}");
            Console.WriteLine($"  Año ....................... {AñoPublicacion}");
            Console.WriteLine($"  Páginas ................... {NumeroPaginas}");
            Console.WriteLine($"  Idioma ...................... {Idioma}");
            Console.WriteLine($"  Género .................... {Genero}");
            Console.WriteLine($"  Estado .................... {(Disponible ? "DISPONIBLE" : "PRESTADO")}");
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine();
        }

        //Mostrar el tiempo que se puede prestar el libro
        public override void DiasPrestamo()
        {
            Console.WriteLine(" ✧˖° LIBRO: Se puede prestar por 21 días (3 semanas)");
        }
    }

    //CLASE REVISTA
    public class Revista : Publicacion
    {
        public int NumeroEdicion { get; set; }
        public string Periodicidad { get; set; } = ""; // Mensual, Semanal, etc.
        public string Categoria { get; set; } = "";

        //Mostrar la informacion de la revista
        public override void MostrarInformacion()
        {
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine($"  ✧˖°. REVISTA: {Nombre} ✧˖°.");
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine($"  Editor .................... {Autor}");
            Console.WriteLine($"  Editorial ................. {Editorial}");
            Console.WriteLine($"  Año ....................... {AñoPublicacion}");
            Console.WriteLine($"  Edición ................... #{NumeroEdicion}");
            Console.WriteLine($"  Periodicidad .............. {Periodicidad}");
            Console.WriteLine($"  Categoría ................. {Categoria}");
            Console.WriteLine($"  Estado .................... {(Disponible ? "DISPONIBLE" : "PRESTADO")}");
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine();
        }

        //Mostrar el tiempo que se puede prestar la revista
        public override void DiasPrestamo()
        {
            Console.WriteLine(" ✧˖° REVISTA: Se puede prestar por 14 días (2 semanas)");
        }

    }

    //CLASE AUDIOLIBRO
    public class AudioLibro : Publicacion
    {
        public int DuracionMinutos { get; set; }
        public string Narrador { get; set; } = "";
        public string Idioma { get; set; } = "";

        //Mostrar la informacion del audiolibro
        public override void MostrarInformacion()
        {
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine($" ✧˖°. AUDIOLIBRO: {Nombre} ✧˖°.");
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine($"  Autor ..................... {Autor}");
            Console.WriteLine($"  Editorial ................. {Editorial}");
            Console.WriteLine($"  Año ....................... {AñoPublicacion}");
            Console.WriteLine($"  Duración .................. {DuracionMinutos} min ({DuracionMinutos / 60.0:F1} horas)");
            Console.WriteLine($"  Narrador .................. {Narrador}");
            Console.WriteLine($"  Idioma ................... {Idioma}");
            Console.WriteLine($"  Estado .................... {(Disponible ? "DISPONIBLE" : "PRESTADO")}");
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine();
        }
        
        //Mostrar el tiempo que se puede prestar el el audiolibro
        public override void DiasPrestamo()
        {
            Console.WriteLine(" ✧˖° AUDIOLIBRO: Se puede prestar por 7 días (1 semana)");
        }
    }
    

}