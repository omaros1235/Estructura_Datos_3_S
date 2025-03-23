using System;

public class NodoArbol
{
    public string Dato { get; set; }
    public NodoArbol Izquierda { get; set; }
    public NodoArbol Derecha { get; set; }

    public NodoArbol(string dato)
    {
        Dato = dato;
        Izquierda = null;
        Derecha = null;
    }
}

public class ArbolBinario
{
    public NodoArbol Raiz { get; set; }

    public ArbolBinario()
    {
        Raiz = null;
    }

    public void Insertar(string dato)
    {
        Raiz = InsertarRecursivo(Raiz, dato);
    }

    private NodoArbol InsertarRecursivo(NodoArbol nodo, string dato)
    {
        if (nodo == null)
        {
            return new NodoArbol(dato);
        }

        if (string.Compare(dato, nodo.Dato) < 0)
        {
            nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, dato);
        }
        else if (string.Compare(dato, nodo.Dato) > 0)
        {
            nodo.Derecha = InsertarRecursivo(nodo.Derecha, dato);
        }

        return nodo;
    }

    public bool Buscar(string dato)
    {
        return BuscarRecursivo(Raiz, dato);
    }

    private bool BuscarRecursivo(NodoArbol nodo, string dato)
    {
        if (nodo == null)
        {
            return false;
        }

        if (string.Compare(dato, nodo.Dato) == 0)
        {
            return true;
        }

        if (string.Compare(dato, nodo.Dato) < 0)
        {
            return BuscarRecursivo(nodo.Izquierda, dato);
        }
        else
        {
            return BuscarRecursivo(nodo.Derecha, dato);
        }
    }

    public void RecorridoInorden()
    {
        RecorridoInordenRecursivo(Raiz);
        Console.WriteLine();
    }

    private void RecorridoInordenRecursivo(NodoArbol nodo)
    {
        if (nodo != null)
        {
            RecorridoInordenRecursivo(nodo.Izquierda);
            Console.Write(nodo.Dato + " ");
            RecorridoInordenRecursivo(nodo.Derecha);
        }
    }

    public void RecorridoPreorden()
    {
        RecorridoPreordenRecursivo(Raiz);
        Console.WriteLine();
    }

    private void RecorridoPreordenRecursivo(NodoArbol nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Dato + " ");
            RecorridoPreordenRecursivo(nodo.Izquierda);
            RecorridoPreordenRecursivo(nodo.Derecha);
        }
    }

    public void RecorridoPostorden()
    {
        RecorridoPostordenRecursivo(Raiz);
        Console.WriteLine();
    }

    private void RecorridoPostordenRecursivo(NodoArbol nodo)
    {
        if (nodo != null)
        {
            RecorridoPostordenRecursivo(nodo.Izquierda);
            RecorridoPostordenRecursivo(nodo.Derecha);
            Console.Write(nodo.Dato + " ");
        }
    }
}

public class Programa
{
    public static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion;

        do
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Insertar dato");
            Console.WriteLine("2. Buscar dato");
            Console.WriteLine("3. Recorrido Inorden");
            Console.WriteLine("4. Recorrido Preorden");
            Console.WriteLine("5. Recorrido Postorden");
            Console.WriteLine("6. Salir");
            Console.Write("Ingrese la opción: ");

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el dato a insertar: ");
                        string datoInsertar = Console.ReadLine();
                        arbol.Insertar(datoInsertar);
                        break;
                    case 2:
                        Console.Write("Ingrese el dato a buscar: ");
                        string datoBuscar = Console.ReadLine();
                        bool encontrado = arbol.Buscar(datoBuscar);
                        Console.WriteLine($"El dato '{datoBuscar}' {(encontrado ? "se encontró" : "no se encontró")} en el árbol.");
                        break;
                    case 3:
                        Console.Write("Recorrido Inorden: ");
                        arbol.RecorridoInorden();
                        break;
                    case 4:
                        Console.Write("Recorrido Preorden: ");
                        arbol.RecorridoPreorden();
                        break;
                    case 5:
                        Console.Write("Recorrido Postorden: ");
                        arbol.RecorridoPostorden();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        } while (opcion != 6);
    }
}