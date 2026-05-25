// Övning 2 - Flöde via loopar och strängmanipulation
// Huvudmeny med switch-sats och while-loop som håller programet vid liv

public static class Menu
{
    // Huvudmeny - punkt 1-4 i övningen 
    public static void Run()
    {
        Console.WriteLine("Välkommen till Applicationer!");
        while (true)
        {
            Console.WriteLine("Välja mellan");
            Console.Write("(0)Anvsluta, (1)Bio-pris[enkel], (2)Bio-pris[grupp], (3)Upprepa text, (4)Tredje Ordet: ");
            string val = (Console.ReadLine() ?? "").ToLower(); // ?? "" fallback om ReadLine returnera null
            switch (val)
            {
                case "0":
                    Console.Clear();
                    Console.WriteLine("Hej då!");
                    return; // Avslutar while-loop och programet
                case "1":
                    Console.WriteLine("Bio-pris [enkel]");
                    Console.Clear();
                    BioEnkel();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Bio-pris [grupp]");
                    BioGrupp();
                    break;
                case "3":
                    Console.Clear();

                    Console.WriteLine("Upprepa Text");
                    UpprepaText();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Tredje Ordet");
                    TredjeOrdet();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Felaktig Input!");
                    break;
            }
        }

    }
    // Menyval 1: Ungdom eller pensionär - nästlad if-sats 
    // Returnerar pris (int) så BioGrupp kan återanvända metoden 
    // Extra: barn under 5 och pensionär över 100 går gratis
    private static int BioEnkel()
    {
        // Lagring
        int pris = 0;

        // Logic
        while (true)
        {
            Console.Write("Ange ålder: ");
            if (int.TryParse(Console.ReadLine(), out int age)) // TryParse = validering att input är ett heltal
            {
                Console.WriteLine($"Ålder: {age}");

                // Prislogik med nästlad
                if (age < 5)
                {
                    pris = 0;
                    Console.WriteLine("Gratis!");
                }
                else if (age < 20)
                {
                    pris = 80;
                    Console.WriteLine($"Ungdomspris: {pris}kr");
                }
                else if (age < 65)
                {
                    pris = 120;
                    Console.WriteLine($"Standardpris: {pris}kr");
                }
                else if (age < 100)
                {
                    pris = 90;
                    Console.WriteLine($"Pensinärspris: {pris}kr");
                }
                else
                {
                    pris = 0;
                    Console.WriteLine("Gratis!");
                }

                return pris;
            }
            Console.Clear();
            Console.WriteLine("Felaktig inmatning! Försök igen!");
        }
    }

    // Menyval 1 (case 2): Räkna ut pris för ett helt sällskap
    // Återanvänder BioEnkel() i för-loop
    private static void BioGrupp()
    {
        // Lagring 
        List<int> amounts = new();
        int total = 0;

        // Logic

        while (true)
        {
            Console.WriteLine("Hur många personer i sällskapet?: ");
            if (int.TryParse(Console.ReadLine(), out int nPersons))
            {
                // Fråga ålder för varje person i sällskapet
                for (int i = 0; i < nPersons; i++)
                {
                    amounts.Add(BioEnkel());
                }
                total = amounts.Sum();
                // Sammanfattning: antal + nTotalkostnad
                Console.WriteLine($"Total personer: {nPersons}\nTotalkostnad: {total}");
                return;
            }
            Console.WriteLine("Felaktig inmatning! Måste vara en heltal.\n Försök igen!");
        }
    }

    // Menyval 3: Det tredje ordet - .Split() med StringSplitOptions
    // Extra: hanterar flera mellanslag i rad med RemoveEmptyEntries
    private static void TredjeOrdet()
    {
        while (true)
        {
            Console.WriteLine("Skriv en menning, mer en 3 ord: ");
            string menning = Console.ReadLine() ?? "";
            string[] words = menning.Split(" ", StringSplitOptions.RemoveEmptyEntries); // RemoveEmptyEntries = ignorerar extra mellanslag
            int nWords = words.Count();
            if (nWords > 2)
            {
                // Index [2] = tredje element (array börjar på 0)
                Console.WriteLine($"Det tredje ordet är: {words[2]}");
                return;
            }
            Console.WriteLine("Meningen måste innehålla minst 3 ord. Försök igen!");
        }
    }

    // Menyval 2: Upprepa tio gånger - for loop utan radbryt
    // Extra: validering att  input inte är tom
    private static void UpprepaText()
    {
        while (true)
        {
            Console.Write("Skriv en text att Upprepa: ");
            string text = Console.ReadLine() ?? "";

            if (!string.IsNullOrEmpty(text))
            {
                for (int i = 1; i < 11; i++)
                {
                    if (i < 10)
                    {
                        Console.Write($"{i}. {text} ");
                    }
                    else
                    {
                        Console.Write($"{i}. {text}\n");
                    }
                }
                return;
            }
            Console.WriteLine("Försök igen!");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Menu.Run();
    }

}
