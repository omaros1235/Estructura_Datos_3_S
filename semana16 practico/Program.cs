﻿using System;
using System.Collections.Generic;

class Grafo
{
    private Dictionary<string, Dictionary<string, int>> vuelos = new();

    public void AgregarCiudad(string ciudad)
    {
        if (!vuelos.ContainsKey(ciudad))
        {
            vuelos[ciudad] = new Dictionary<string, int>();
        }
    }

    public void AgregarVuelo(string origen, string destino, int costo)
    {
        AgregarCiudad(origen);
        AgregarCiudad(destino);
        vuelos[origen][destino] = costo;
    }

    public void Dijkstra(string origen, string destino)
    {
        var costos = new Dictionary<string, int>();
        var visitado = new HashSet<string>();
        var anterior = new Dictionary<string, string>();
        var ciudades = new List<string>(vuelos.Keys);

        foreach (var ciudad in ciudades)
        {
            costos[ciudad] = int.MaxValue;
        }

        costos[origen] = 0;

        while (visitado.Count < vuelos.Count)
        {
            string actual = null;
            int menorCosto = int.MaxValue;

            foreach (var ciudad in vuelos.Keys)
            {
                if (!visitado.Contains(ciudad) && costos[ciudad] < menorCosto)
                {
                    menorCosto = costos[ciudad];
                    actual = ciudad;
                }
            }

            if (actual == null)
                break;

            visitado.Add(actual);

            foreach (var vecino in vuelos[actual])
            {
                int nuevoCosto = costos[actual] + vecino.Value;
                if (nuevoCosto < costos[vecino.Key])
                {
                    costos[vecino.Key] = nuevoCosto;
                    anterior[vecino.Key] = actual;
                }
            }
        }

        // Mostrar resultados
        Console.WriteLine($"\nCosto mínimo de {origen} a {destino}: {costos[destino]}");

        // Reconstrucción de la ruta
        var ruta = new Stack<string>();
        string nodo = destino;

        while (nodo != null && anterior.ContainsKey(nodo))
        {
            ruta.Push(nodo);
            nodo = anterior[nodo];
        }

        if (nodo == origen)
        {
            ruta.Push(origen);
            Console.Write("Ruta: ");
            Console.WriteLine(string.Join(" -> ", ruta));
        }
        else
        {
            Console.WriteLine("No se encontró una ruta.");
        }
    }
}

class Programa
{
    static void Main()
    {
        var grafo = new Grafo();

        // Datos simulados
        grafo.AgregarVuelo("Quito", "Guayaquil", 80);
        grafo.AgregarVuelo("Quito", "Cuenca", 60);
        grafo.AgregarVuelo("Cuenca", "Guayaquil", 40);
        grafo.AgregarVuelo("Guayaquil", "Loja", 70);
        grafo.AgregarVuelo("Cuenca", "Loja", 50);
        grafo.AgregarVuelo("Quito", "Loja", 120);

        Console.Write("Ciudad de origen: ");
        string origen = Console.ReadLine();

        Console.Write("Ciudad de destino: ");
        string destino = Console.ReadLine();

        grafo.Dijkstra(origen, destino);
    }
}