using System;

class AutomatBauturi
{
    static void Main()
    {
        
        SimuleazaAutomat();
    }

    static void SimuleazaAutomat()
    {
        string[] alfabet = { "C", "T", "A", "H", "OK" };
        string[] stari = { "q0", "q1", "q2", "q3", "q4" };

        string stareCurenta = "q0";

        Console.WriteLine("Bine ati venit la automatul de bauturi!");
        Console.WriteLine("Alegeti o bautura (C - cafea, T - ceai, A - cappuccino, H - ciocolata calda) si apoi apasati OK pentru a confirma:");

        while (stareCurenta != "q4")
        {
            Console.Write($"Stare curenta: {stareCurenta}. Introduceti o intrare ({string.Join(", ", alfabet)}): ");
            string intrare = Console.ReadLine().ToUpper();

            if (Array.Exists(alfabet, element => element == intrare))
            {
                stareCurenta = Delta(stareCurenta, intrare);
            }
            else
            {
                Console.WriteLine("Intrare invalida. Va rugam sa alegeti o optiune valida.");
            }
        }

        Console.WriteLine("Comanda finalizata. Va multumim!");
    }

    static string Delta(string stareCurenta, string intrare)
    {
        switch (stareCurenta)
        {
            case "q0":
                switch (intrare)
                {
                    case "C": return "q1";
                    case "T": return "q2";
                    case "A": return "q3";
                    case "H": return "q4";
                    case "OK": return "q0";
                    default: return stareCurenta;
                }
            case "q1":
            case "q2":
            case "q3":
                if (intrare == "OK") return "q4";
                else return stareCurenta;
            case "q4":
                if (intrare == "OK") return "q0";
                else return stareCurenta;
            default:
                return stareCurenta;
        }
    }
}
