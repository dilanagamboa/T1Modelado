namespace BibliotecaLuna;

public class Usuarios
{
    private string _tipoUsuario;
    private string _nombre;

    public string TipoUsuario
    {
        get => _tipoUsuario;
        set => _tipoUsuario = value;
    }

    public string Nombre
    {
        get => _nombre;
        set => _nombre = value;
    }

    public Usuarios(string tipoUsuario, string nombre)
    {
        TipoUsuario = tipoUsuario;
        Nombre = nombre;
    }

    public void ImprimeDatos()
    {
        Console.WriteLine($"Tipo de Usuario: {TipoUsuario}");
        Console.WriteLine($"Nombre: {Nombre}");
    }
}
