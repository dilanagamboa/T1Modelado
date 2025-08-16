using System;
using System.Collections.Generic;

namespace BibliotecaElegante
{
    //la base 
    public class Entidad
    {
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    }

    //publicación abstracta
    public abstract class Publicacion : Entidad
    {
    public string Autor { get; set; } = "";
    public int AnioPublicacion { get; set; }
    public abstract void MostrarInformacion();
    }

    //clase biblioteca (funciona como gestor principal)
    public class Biblioteca
    {
        private List<Publicacion> publicaciones;

        public Biblioteca()
        {
            publicaciones = new List<Publicacion>();
        }

        public void AgregarPublicacion(Publicacion publicacion)
        {
            publicaciones.Add(publicacion);
        }

        public void ListarPublicaciones()
        {
            foreach (var pub in publicaciones)
            {
                pub.MostrarInformacion();
            }
        }
    }
}
