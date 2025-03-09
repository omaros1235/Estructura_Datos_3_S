using System;
using System.Collections.Generic;


public class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Genero { get; set; }
    public bool Disponible { get; set; } = true;
}

public class Biblioteca
{
    public Dictionary<int, Libro> Libros { get; set; } = new Dictionary<int, Libro>();
    public HashSet<string> Generos { get; set; } = new HashSet<string>();
    public Dictionary<string, List<Libro>> LibrosPorGenero { get; set; } = new Dictionary<string, List<Libro>>();
}

public class Programa
{
    public static Biblioteca biblioteca = new Biblioteca();

    public static void RegistrarLibro(Libro libro)
    {
        biblioteca.Libros[libro.Id] = libro;
        biblioteca.Generos.Add(libro.Genero);

        if (biblioteca.LibrosPorGenero.ContainsKey(libro.Genero))
        {
            biblioteca.LibrosPorGenero[libro.Genero].Add(libro);
        }
        else
        {
            biblioteca.LibrosPorGenero[libro.Genero] = new List<Libro> { libro };
        }
    }

    public static Libro BuscarLibroPorId(int idLibro)
    {
        if (biblioteca.Libros.ContainsKey(idLibro))
        {
            return biblioteca.Libros[idLibro];
        }
        return null;
    }

    public static List<Libro> BuscarLibrosPorGenero(string genero)
    {
        if (biblioteca.LibrosPorGenero.ContainsKey(genero))
        {
            return biblioteca.LibrosPorGenero[genero];
        }
        return new List<Libro>(); // Evitar devolver null
    }

    public static void PrestarLibro(int idLibro)
    {
        Libro libro = BuscarLibroPorId(idLibro);
        if (libro != null && libro.Disponible)
        {
            libro.Disponible = false;
            Console.WriteLine($"✅ Libro '{libro.Titulo}' ha sido prestado.");
        }
        else
        {
            Console.WriteLine("❌ Libro no encontrado o ya prestado.");
        }
    }

    public static void DevolverLibro(int idLibro)
    {
        Libro libro = BuscarLibroPorId(idLibro);
        if (libro != null && !libro.Disponible)
        {
            libro.Disponible = true;
            Console.WriteLine($"🔄 Libro '{libro.Titulo}' ha sido devuelto.");
        }
        else
        {
            Console.WriteLine("❌ Libro no encontrado o ya estaba disponible.");
        }
    }

    public static void Main(string[] args)
    {
        try
        {
            Libro libro1 = new Libro { Id = 1, Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", Genero = "Novela" };
            Libro libro2 = new Libro { Id = 2, Titulo = "El señor de los anillos", Autor = "J.R.R. Tolkien", Genero = "Fantasía" };
            Libro libro3 = new Libro { Id = 3, Titulo = "La ciudad de los prodigios", Autor = "Eduardo Mendoza", Genero = "Novela" };

            RegistrarLibro(libro1);
            RegistrarLibro(libro2);
            RegistrarLibro(libro3);

            Console.WriteLine("\n🔍 Buscando libro por ID (2)...");
            Libro libroEncontrado = BuscarLibroPorId(2);
            if (libroEncontrado != null)
            {
                Console.WriteLine($"✅ Libro encontrado: {libroEncontrado.Titulo} ({libroEncontrado.Autor})");
            }

            Console.WriteLine("\n📚 Listando libros del género 'Novela'...");
            List<Libro> librosNovela = BuscarLibrosPorGenero("Novela");
            foreach (var libro in librosNovela)
            {
                Console.WriteLine($"- {libro.Titulo} ({libro.Autor})");
            }

            Console.WriteLine("\n📖 Intentando prestar el libro con ID 1...");
            PrestarLibro(1);

            Console.WriteLine("\n🔄 Devolviendo el libro con ID 1...");
            DevolverLibro(1);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }
}
