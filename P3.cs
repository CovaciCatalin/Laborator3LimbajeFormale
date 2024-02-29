using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Introducet0i calea catre fisierul text de verificat:");
        string filePath = Console.ReadLine();

        try
        {
            string fileContent = File.ReadAllText(filePath);

            string clientInfoPattern = @"Client: (.+)";
            string productDetailsPattern = @"Produs: (.+), Pret: (\d+\.\d+), TVA: (\d+%), Cantitate: (\d+)";

            
            CheckSection(fileContent, "Informatii despre client", clientInfoPattern);
            CheckSection(fileContent, "Detalii despre produse", productDetailsPattern);

            Console.WriteLine("Fisierul respectă formatul specificat.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la citirea sau verificarea fisierului: {ex.Message}");
        }
    }

    static void CheckSection(string content, string sectionName, string pattern)
    {
        Console.WriteLine($"Verificare {sectionName}...");

        MatchCollection matches = Regex.Matches(content, pattern);
        if (matches.Count == 0)
        {
            Console.WriteLine($"Eroare: {sectionName} nu respectă formatul specificat.");
        }
        else
        {
            foreach (Match match in matches)
            {
                Console.WriteLine($"{sectionName}: {match.Groups[1].Value}");
            }
        }

        Console.WriteLine();
    }
}
