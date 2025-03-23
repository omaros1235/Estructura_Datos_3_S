using System;
using System.Collections.Generic;

public class CatalogoRevistas
{
    private List<string> titulosRevistas;

    public CatalogoRevistas()
    {
        titulosRevistas = new List<string>();
    }

    public void AgregarTitulo(string titulo)
    {
        titulosRevistas.Add(titulo);
    }

    public bool BuscarTituloIterativo(string titulo)
    {
        foreach (string t in titulosRevistas)
        {
            if (t.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    public bool BuscarTituloRecursivo(string titulo, int indice)
    {
        if (indice < 0 || indice >= titulosRevistas.Count)
        {
            return false;
        }

        if (titulosRevistas[indice].Equals(titulo, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        return BuscarTituloRecursivo(titulo, indice + 1);
    }

    public void MostrarMenu()
    {
        Console.WriteLine("Catálogo de Revistas");
        Console.WriteLine("1. Buscar título (iterativo)");
        Console.WriteLine("2. Buscar título (recursivo)");
        Console.WriteLine("3. Salir");
        Console.Write("Seleccione una opción: ");
    }

    public static void Main(string[] args)
    {
        CatalogoRevistas catalogo = new CatalogoRevistas();

        // Agregar 10 títulos de revistas
        catalogo.AgregarTitulo("National Geographic");
        catalogo.AgregarTitulo("Time");
        catalogo.AgregarTitulo("Forbes");
        catalogo.AgregarTitulo("Science");
        catalogo.AgregarTitulo("Nature");
        catalogo.AgregarTitulo("The Economist");
        catalogo.AgregarTitulo("Wired");
        catalogo.AgregarTitulo("Vogue");
        catalogo.AgregarTitulo("Sports Illustrated");
        catalogo.AgregarTitulo("Rolling Stone");

        int opcion;
        do
        {
            catalogo.MostrarMenu();
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el título a buscar: ");
                        string tituloIterativo = Console.ReadLine();
                        bool encontradoIterativo = catalogo.BuscarTituloIterativo(tituloIterativo);
                        Console.WriteLine(encontradoIterativo ? "Encontrado" : "No encontrado");
                        break;
                    case 2:
                        Console.Write("Ingrese el título a buscar: ");
                        string tituloRecursivo = Console.ReadLine();
                        bool encontradoRecursivo = catalogo.BuscarTituloRecursivo(tituloRecursivo, 0);
                        Console.WriteLine(encontradoRecursivo ? "Encontrado" : "No encontrado");
                        break;
                    case 3:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida.");
            }
            Console.WriteLine();
        } while (opcion != 3);
    }
}