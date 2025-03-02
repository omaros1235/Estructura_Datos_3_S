using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Diccionario inicial con palabras en inglés y español
        Dictionary<string, string> dictionary = new Dictionary<string, string>
        {
            { "time", "tiempo" },
            { "person", "persona" },
            { "year", "año" },
            { "way", "camino/forma" },
            { "day", "día" },
            { "thing", "cosa" },
            { "man", "hombre" },
            { "world", "mundo" },
            { "life", "vida" },
            { "hand", "mano" },
            { "part", "parte" },
            { "child", "niño/a" },
            { "eye", "ojo" },
            { "woman", "mujer" },
            { "place", "lugar" },
            { "work", "trabajo" },
            { "week", "semana" },
            { "case", "caso" },
            { "point", "punto/tema" },
            { "government", "gobierno" },
            { "company", "empresa/compañía" }
        };

        while (true)
        {
            Console.WriteLine("\nMENU");
            Console.WriteLine("=======================================================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Ingresar más palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    TranslatePhrase(dictionary);
                    break;
                case "2":
                    AddWordsToDictionary(dictionary);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void TranslatePhrase(Dictionary<string, string> dictionary)
    {
        Console.Write("Ingrese la frase: Este día es hermoso, depende mucho del ojo que lo ve.");
        string input = Console.ReadLine();
        string[] words = input.Split(' ');
        List<string> translatedWords = new List<string>();

        foreach (string word in words)
        {
            string lowerWord = word.ToLower().Trim(new char[] { '.', ',', '!', '?' }); // Eliminar puntuación
            if (dictionary.ContainsKey(lowerWord))
            {
                translatedWords.Add(dictionary[lowerWord]);
            }
            else
            {
                // Si la palabra no está en el diccionario, se mantiene la palabra original
                translatedWords.Add(word);
            }
        }

        string translatedPhrase = string.Join(" ", translatedWords);
        Console.WriteLine("Su frase traducida es: " + translatedPhrase);
    }

    static void AddWordsToDictionary(Dictionary<string, string> dictionary)
    {
        Console.Write("Ingrese la palabra en inglés:Este día es hermoso, depende mucho del ojo que lo ve.");
        string englishWord = Console.ReadLine().ToLower();
        Console.Write("Ingrese la traducción en español:this day es hermoso, depende mucho del eye que lo ve.");
        string spanishWord = Console.ReadLine().ToLower();

        if (!dictionary.ContainsKey(englishWord))
        {
            dictionary.Add(englishWord, spanishWord);
            Console.WriteLine("Palabra agregada al diccionario.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }

        // Agregar la traducción inversa
        if (!dictionary.ContainsKey(spanishWord))
        {
            dictionary.Add(spanishWord, englishWord);
            Console.WriteLine("Traducción inversa agregada al diccionario.");
        }
    }
}