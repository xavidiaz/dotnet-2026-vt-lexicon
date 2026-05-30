using Template_Task_3.DemoClasses;
using Template_Task_3.Helpers;
using Template_Task_3.StackAndHeap;

namespace Template_Task_3;

internal class Program
{
    // Dictionary: snabb uppslagning av produkter via produktkod (key = kod, value = produkt)
    static Dictionary<string, Product> products = new Dictionary<string, Product>();

    // List: enkel logg över vad som hänt i programmet — ordnad och växer dynamiskt
    static List<string> logMessages = new List<string>();

    // Queue: FIFO — kunder betjänas i den ordning de ställde sig i kön
    static Queue<Customer> customerQueue = new Queue<Customer>();

    // Stack: LIFO — används för att kunna ångra den senaste försäljningen
    static Stack<Sale> saleHistory = new Stack<Sale>();

    static string ReadLine => Console.ReadLine() ?? string.Empty;

    static void Main(string[] args)
    {
        //ToDo implementera 
        SeedProducts();
        DebugSeed();
        Console.WriteLine("Tryck valfri tangent för att fortsätta till menyn");
        Console.ReadKey();

        bool running = true;

        do
        {
            PrintMenu();

            Console.Write("Välj: ");
            string choice = ReadLine;

            Console.WriteLine();

            switch (choice)
            {
                case MenuConstants.ShowProducts:
                    PrintProducts();
                    break;

                case MenuConstants.FindProduct:
                    FindProduct();
                    break;

                case MenuConstants.AddProduct:
                    AddProduct();
                    break;

                case MenuConstants.ChangeStock:
                    ChangeStock();
                    break;

                case MenuConstants.GetBetterPrice:
                    Console.Write("Ange produktkod: ");
                    GetPriceBetter(ReadLine.ToUpper());
                    break;

                case MenuConstants.AddCustomerToQueue:
                    AddCustomerToQueue();
                    break;

                case MenuConstants.ServeNextCustomer:
                    ServeNextCustomer();
                    break;

                case MenuConstants.PrintCustomerQueue:
                    PrintCustomerQueue();
                    break;

                case MenuConstants.SellProduct:
                    SellProduct();
                    break;

                case MenuConstants.UndoLastSale:
                    UndoLastSale();
                    break;

                case MenuConstants.PrintLog:
                    PrintLog();
                    break;

                case MenuConstants.ArrayLab:
                    ArrayLab();
                    break;

                case MenuConstants.ListLab:
                    ListLab();
                    break;

                case MenuConstants.ReverseTextLab:
                    ReverseTextLab();
                    break;

                case MenuConstants.WordCountLab:
                    WordCountLab();
                    break;

                case MenuConstants.ParenthesesLab:
                    ParenthesesLab();
                    break;

                case MenuConstants.MemoryLab:
                    MemoryLab();
                    break;

                case MenuConstants.RecursionLab:
                    RecursionLab();
                    break;

                case MenuConstants.SaveLogToFile:
                    SaveLogToFile();
                    break;

                case MenuConstants.Exit:
                    running = false;
                    break;

                default:
                    Console.WriteLine("Felaktigt val.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
            Console.Clear();
        }
        while (running);
    }

    static void PrintMenu()
    {
        Console.WriteLine(MenuConstants.Title);
        Console.WriteLine();

        foreach (MenuItem item in MenuConstants.Items)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
    }

    #region Dictionary

    // ============================================================
    // DEL 1 - PRODUKTER OCH DICTIONARY
    // ============================================================

    static void SeedProducts()
    {
        // Exempel på hur du lägger till en produkt i dictionaryn:
        // products["KAFFE"] = new Product("KAFFE", "Kaffe", 15.00m, 50);
        //
        // TODO:
        // Lägg till minst 10 produkter i products-dictionaryn.
        // Välj egna koder, namn, priser och lagersaldon.

        products["KANE"] = new Product("KANE", "kanelbulle", 20.00m, 30);
        products["CHOK"] = new Product("CHOK", "chokladboll", 25.00m, 50);
        products["PRIN"] = new Product("PRIN", "princesstårta", 55.00m, 10);
        products["WIEN"] = new Product("WIEN", "wienerbröd", 38.20m, 20);
        products["DAMM"] = new Product("DAMM", "dammsugare", 30.00m, 25);
        products["SEML"] = new Product("SEML", "semla", 45.00m, 20);
        products["MAZA"] = new Product("MAZA", "mazarin", 29.00m, 35);
        products["BUDA"] = new Product("BUDA", "budapestrulle", 42.00m, 15);
        products["MUNK"] = new Product("MUNK", "munk", 22.00m, 45);
        products["NAPO"] = new Product("NAPO", "napoleonbakelse", 48.00m, 12);
    }

static void DebugSeed()
{
logMessages.Add("Produkt tillagd: KANE - kanelbulle");
logMessages.Add("Produkt tillagd: CHOK - chokladboll");
logMessages.Add("Lager ändrat: SEML, nytt saldo: 15");
logMessages.Add("Anna ställde sig i kön");
}
    static void PrintProducts()
    {
        Console.WriteLine("=== Produkter ===");

        // TODO:
        // Loopa igenom dictionaryn products.
        // Skriv ut varje produkt.
        // Räkna även ut totalt lagervärde.
        // Lagervärde för en produkt:
        // product.Price * product.Stock

        // Lagring av data
        decimal summa = 0;


        // Logic
        foreach (var (key, product) in products)
        {
            Console.WriteLine(product + Environment.NewLine + $"Lagervärde: {product.Price * product.Stock} kr.");
            summa += product.Price * product.Stock;
        }

        Console.WriteLine(Environment.NewLine + $"Total lagervärde: {summa}." + Environment.NewLine);

        // Fråga:
        // Varför passar Dictionary bra för ett produktregister?
        Console.WriteLine("Svar: TODO - 1. Dictionary är mer idiomatisk (naturligt), slå upp med en meningsfull kod istället för en position i listan. 2. Mindre resurskrävande O(1) istället för O(n)");
    }

    static void FindProduct()
    {
        Console.Write("Ange produktkod: ");


        // TODO:
        // Hämta produktens code
        // Gör koden till stora bokstäver med .ToUpper()
        // Slå upp produkten med TryGetValue
        // Om produkten finns, skriv ut den.
        // Om produkten saknas, skriv ett felmeddelande.

        Console.Write("Ge produkt koden (4 täcken):");
        string code = (Console.ReadLine() ?? "").ToUpper();
        if (products.TryGetValue(code, out Product? product))
        {
            Console.WriteLine(Environment.NewLine + product);
        }
        else
        {
            Console.WriteLine(Environment.NewLine + "Produkt finns inte!");
        }

        // Fråga:
        // Varför är TryGetValue bättre än att skriva products[code] direkt?
        Console.WriteLine(Environment.NewLine + "Svar: TODO - On nycklen inte finns i dictionaryn returneras false istället för att programmet krashar med ett undantag (exception)");
    }

    static void AddProduct()
    {
        // TODO:
        // Läs in produktkod.
        // Gör produktkoden till stora bokstäver med .ToUpper().
        // Kontrollera om koden redan finns i products — skriv felmeddelande om den gör det.
        // Läs in namn.
        // Läs in pris (använd InputHelpers.ReadDecimal).
        // Läs in lagersaldo (använd InputHelpers.ReadInt).
        // Skapa ett Product-objekt.
        // Lägg till produkten i products-dictionaryn.
        // Lägg till ett loggmeddelande i logMessages.

        string produktKod = "";
        while (true)
        {
            produktKod = InputHelpers.ReadString("Ange produkt kod, 4 täcken: ").ToUpper();

            if (produktKod.Length != 4)
            {
                Console.WriteLine("Produkt kod måste ha exakt fyra bokstäver!");
                continue;
            }
            if (products.ContainsKey(produktKod))
            {
                Console.WriteLine("Produkt upptangen, finns redan med annat produkt med dessa kod!");
                continue;
            }
            break;

        }
        string produktNamn = InputHelpers.ReadString("Ange produkt namn: ");
        decimal produktPris = InputHelpers.ReadDecimal("Ange produkt pris: ");
        int produktLagerSaldo = InputHelpers.ReadInt("Ange produkt antal: ");

        products[produktKod] = new Product(produktKod, produktNamn, produktPris, produktLagerSaldo);

        logMessages.Add($"Produkt tillagd: {produktKod} - {produktNamn}");
        Console.WriteLine(products[produktKod]);

        // Fråga:
        // Vad är nyckeln och vad är värdet i products?
        Console.WriteLine("Svar: TODO - nyckeln är en unik identifierare till värdet som är en Produkt-instans.");
    }

    static void ChangeStock()
    {
        // TODO:
        // Läs in produktkod.
        // Slå upp produkten med TryGetValue.
        // Läs in nytt lagersaldo från användaren.
        // Validera
        // Ändra produktens Stock. Validera även i product
        // 
        // Logga ändringen.

        string produktKod = "";
        while (true)
        {
            produktKod = Helpers.InputHelpers.ReadString("Ange produkt kod: ").ToUpper();

            if (produktKod.Length != 4)
            {
                Console.WriteLine("Produkt kod måste ha 4 täcken");
                continue;
            }
            break;
        }
        if (products.TryGetValue(produktKod, out Product? produkt))
        {
            int nyLagerSaldo = Helpers.InputHelpers.ReadInt("Ange ny lagersaldo: ");

            if (nyLagerSaldo < 0)
            {
                Console.WriteLine("Lagersaldo kan inte vara negativt!");
                return;
            }

            produkt.Stock = nyLagerSaldo;

            Console.WriteLine($"Lager ändrat: {produktKod} - {produkt.Name}, nytt saldo: {nyLagerSaldo}");

            logMessages.Add($"Lager ändrat: {produktKod} - {produkt.Name}, nytt saldo: {nyLagerSaldo}");

        }
        else
        {
            Console.WriteLine("Produkt kod finns inte!");
        }
        // OBS: Instruktionen säger "Validera även i Product" — oklart om det ska göras här eller i Product.cs. Återkommer till detta.

    }

    static decimal GetPriceBad(string code)
    {
        if (code == "KAF")
        {
            return 15;
        }
        else if (code == "TE")
        {
            return 12;
        }
        else if (code == "BUL")
        {
            return 18;
        }
        else if (code == "MCK")
        {
            return 35;
        }
        else
        {
            return -1;
        }
    }

    static decimal GetPriceBetter(string code)
    {
        // TODO:
        // Skriv om GetPriceBad med en lokal Dictionary istället för if/else.
        // Samma fyra produkter och priser som i GetPriceBad ska finnas.
        // Använd TryGetValue för att slå upp priset.
        // Returnera priset om koden finns, annars -1.
        //
        Dictionary<string, decimal> betterPrice = new()
        {
            ["KAF"] = 15,
            ["TE"] = 12,
            ["BUL"] = 18,
            ["MCK"] = 35
        };

        if (betterPrice.TryGetValue(code, out decimal pris))
        {
            Console.WriteLine($"{code} = {pris}.");
            return pris;
        }

        // Jämför sedan de två metoderna — vad händer om du behöver lägga till
        // en femte produkt? Vilken metod är enklare att utöka?

        // Fråga:
        // Varför är Dictionary-lösningen bättre än många if/else-satser?
        Console.WriteLine("Svar: TODO");

        Console.WriteLine(
            Environment.NewLine +
            "Jag tycker att det är mer idiomatisk, mer lässbart." +
            "Notation ser ut enklare, då dictionaryn blir lätt att utöka." +
            "Därmed dictionaryn kråver mindre resurser. Behöver inte att gå genom varje 'else if' postående."
            );
        return -1;
    }

    #endregion

    #region Queue

    // ============================================================
    // DEL 2 - QUEUE
    // ============================================================

    static void AddCustomerToQueue()
    {
        // TODO:
        // Läs in kundens namn (använd InputHelpers.ReadString).
        // Skapa ett Customer-objekt med namnet.
        // Lägg kunden i customerQueue med Enqueue.
        // Skriv ut att kunden lagts till och vilken plats i kön de har.
        // Lägg till ett loggmeddelande i logMessages.

        string name = Helpers.InputHelpers.ReadString("Ange kundnamn: ");
        customerQueue.Enqueue(new Customer(name));

        Console.WriteLine($"{name} har lagts till på {customerQueue.Count} plats.");
        logMessages.Add($"{name} har lagts till på {customerQueue.Count} plats.");

        // Fråga:
        // Vad betyder FIFO?
        Console.WriteLine("Svar: TODO" +
            Environment.NewLine +
            "FIFO betyder First In, First Out. " +
            Environment.NewLine +
            "Den som läggs till först i kön tas ut först vid Dequeue(). Som en riktig kö in en butik."
            );
    }

    static void ServeNextCustomer()
    {
        // TODO:
        // Kontrollera om customerQueue är tom — skriv meddelande om den är det.
        // Om den inte är tom:
        // Använd Dequeue för att ta bort och hämta den första kunden.
        // Skriv ut vilken kund som blev betjänad.
        // Lägg till ett loggmeddelande i logMessages.
        if (customerQueue.Count == 0)
        {
            Console.WriteLine("Kö är tom!");
        }
        else
        {
            Customer kund = customerQueue.Dequeue();
            Console.WriteLine($"{kund} blev betjänad!");
            logMessages.Add($"{kund} blev betjänad!");
        }
        // Fråga:
        // Varför passar Queue bättre än Stack för en kundkö?
        Console.WriteLine(
            Environment.NewLine +
            "Svar:" +
            "Queue (FIFO) passar bättre för en kundkö eftersom kunder ska betjänas i den ordning de ställde sig i kön." +
            "Med Stack (LIFO) skulle den sista kunden bethänas först, vilket vore orättvist."
            );
    }

    static void PrintCustomerQueue()
    {
        // TODO:
        // Om customerQueue är tom, skriv att kön är tom.
        // Annars: loopa igenom customerQueue med en räknare.
        // Skriv ut platsnummer, namn och tidsstämpel för varje kund.
        //
        if (customerQueue.Count == 0)
        {
            Console.WriteLine("Kön är tom!");
        }
        else
        {
            int plats = 1;
            foreach (Customer kund in customerQueue)
            {
                Console.WriteLine($"{plats++}. {kund}");
            }
        }
        // Exempel:
        // 1. Kalle (2026-05-26 10:01)
        // 2. Greta (2026-05-26 10:02)
        // 3. Stina (2026-05-26 10:03)
        //
        // Tips: foreach fungerar på Queue utan att ta bort elementen.

        Console.WriteLine("TODO: Implementera PrintCustomerQueue.");
    }

    #endregion

    #region Stack

    // ============================================================
    // DEL 3 - STACK OCH FÖRSÄLJNING
    // ============================================================

    static void SellProduct()
    {
        // TODO:
        // Kontrollera om customerQueue är tom — skriv meddelande om den är det.
        // Använd Peek för att se vilken kund som står först (utan att ta bort dem).
        // Läs in produktkod.
        // Slå upp produkten med TryGetValue.
        // Kontrollera att produkten finns i lager (Stock > 0).
        // Minska produktens Stock med 1.
        // Skapa ett Sale-objekt med produktinfo och kundens namn.
        // Lägg Sale-objektet på saleHistory med Push.
        // Lägg till ett loggmeddelande i logMessages.
        //
        if (customerQueue.Count == 0)
        {
            Console.WriteLine("kundenskö är tom!");
        }
        else
        {
            Customer first = customerQueue.Peek();
            Console.WriteLine($"Betjänar: {first.Name}");

            string produktkod = Helpers.InputHelpers.ReadString("Ange produktkod: ").ToUpper();
            if (products.TryGetValue(produktkod, out Product? product))
            {
                if (product.Stock > 0)
                {
                    product.Stock--;
                    Customer kund = customerQueue.Dequeue();
                    saleHistory.Push(new Sale(product.Code, product.Name, product.Price, kund.Name));
                    logMessages.Add($"försäljning: {product.ToString()} till {kund.Name}");
                }
                else
                {
                    Console.WriteLine("Ej i Stock");
                }
            }
        }


        // Extra:
        // Bestäm om kunden ska tas bort från kön efter köp eller inte.
        // Motivera ditt val i kommentar.


        // Fråga:
        // Varför sparar vi försäljningar i en Stack?
        Console.WriteLine(
            Environment.NewLine +
            "Svar:" +
            "Eftersom oftas man vill ändras sista försäljningen, inte den första. Det blir mer effektiv i dess ordning"
            );
    }

    static void UndoLastSale()
    {
        Console.WriteLine("TODO: Implementera UndoLastSale.");

        // TODO:
        // Kontrollera om saleHistory är tom — skriv meddelande om den är det.
        // Om den inte är tom:
        // Använd Pop för att hämta och ta bort senaste försäljningen.
        // Slå upp produkten i products med försäljningens ProductCode.
        // Öka produktens Stock med 1.
        // Logga vad som ångrades i logMessages.

if (saleHistory.Count == 0)
{
    Console.WriteLine("Sale History är tom!");
}
else
{
    Sale last = saleHistory.Pop();
    string code = last.ProductCode;
    Console.WriteLine("Here - " + code);
    if (products.TryGetValue(code, out Product? p))
    {
        p.Stock++;
        logMessages.Add($"Ångrad försäljning: {last}");
        Console.WriteLine($"Ångrad försäljning: {last}");
    }
}      

        // Fråga:
        // Vad betyder LIFO?
        Console.WriteLine(
            "Svar" +
            Environment.NewLine +
            "LIFO - Last in, First Out." +
            "senaste elemenetet som lades till tas ut först." +
            "Det är det mest intresanta valet i detta fall eftersom man vanligtvis vill ändra det senast tillagda elemenetet"

            );
    }

    static void ReverseTextLab()
    {
        Console.WriteLine("=== Stack-labb: vänd text ===");

        // TODO:
        // Läs in en text från användaren.
        // Skriv ut texten bakofram använd en lämplig collektion.
        Console.Write("Ange text att skriva bakofram: ");
        string text = Console.ReadLine() ?? "";
        string bakofram = "";

        Stack<Char> textChar = new();

        foreach (char t in text){
          textChar.Push(t);
        }
        if (text.Length == 0){
          Console.WriteLine("Tom inmantning!");
        }
        else
        {
        while(textChar.Count > 0){
          bakofram += textChar.Pop();
        }
        Console.WriteLine($"bakofram = {bakofram}");


        }
    }

    #endregion

    #region List

    // ============================================================
    // DEL 4 - LIST
    // ============================================================

    static void PrintLog()
    {
        Console.WriteLine("=== Logg ===");

        // TODO:
        // Om logMessages är tom, skriv "Inga loggmeddelanden finns."
        // Annars: loopa igenom logMessages och skriv ut varje meddelande.

        Console.WriteLine("TODO: Implementera PrintLog.");
        if(logMessages.Count == 0){
          Console.WriteLine("Inga loggmeddelanden finns!");
        }
        else
        {
          foreach(string log in logMessages)
          {
            Console.WriteLine(log);
          }
        }

        // Fråga:
        // Varför passar List bra för loggmeddelanden?
        Console.WriteLine(
            "Svar:" +
            Environment.NewLine +
            "List sparar i ordning och alla meddelande är lättillgängliga via index (list[i]) utan att något tas bort."

            );
    }

    static void ListLab()
    {
        Console.WriteLine("=== List-labb ===");

        List<string> shoppingList = new List<string>();

        PrintListInfo(shoppingList, "Start");

        shoppingList.Add("Mjölk");
        PrintListInfo(shoppingList, "Efter Mjölk");

        shoppingList.Add("Bröd");
        PrintListInfo(shoppingList, "Efter Bröd");

        shoppingList.Add("Smör");
        PrintListInfo(shoppingList, "Efter Smör");

        shoppingList.Add("Ost");
        PrintListInfo(shoppingList, "Efter Ost");

        shoppingList.Add("Yoghurt");
        PrintListInfo(shoppingList, "Efter Yoghurt");

        shoppingList.Remove("Smör");
        PrintListInfo(shoppingList, "Efter Remove");

        // TODO:
        // Lägg till minst 4 egna varor med en loop.
        // Skriv ut hela listan.
       
        string[] extraVaror = ["Ris","Gurka", "Sallad", "Te"];
        foreach(string vara in extraVaror){
          shoppingList.Add(vara);
        }
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("-- Listan --");
        foreach(string vara in shoppingList){
          Console.WriteLine(vara);
        }

        Console.WriteLine(Environment.NewLine);
        // Fråga 1:
        // Vad betyder Count?
        Console.WriteLine(
            "Svar 1:" +
            Environment.NewLine +
            "Antal element som faktiskt finns i listan"
            );

        // Fråga 2:
        // Vad betyder Capacity?
        Console.WriteLine(
            "Svar 2:" + 
            Environment.NewLine +
            "Mängden plats som listan har reserverat i minnet. Kan det vara lika med eller store än Count."
            );

        // Fråga 3:
        // Varför ökar inte Capacity med exakt 1 varje gång?
        Console.WriteLine(
            "Svar 3: " + 
            Environment.NewLine +
            "Eftersom minnet fördubblas när kräver store Count än lika, med (0->4->8->16->32)."
            );

        // Fråga 4:
        // Minskar Capacity automatiskt när element tas bort?
        Console.WriteLine(
            "Svar 4:" + 
            Environment.NewLine + 
            "Capacity minskar aldrig automatiskt vid borttagning. Listan behåller reservat minne." +
            "För att kunna frias minne används <lista>.TrimExcess()."
            );
    }

    static void PrintListInfo(List<string> list, string message)
    {
        Console.WriteLine($"{message}: Count = {list.Count}, Capacity = {list.Capacity}");
    }

    #endregion

    #region Array

    // ============================================================
    // DEL 5 - ARRAY
    // ============================================================

    static void ArrayLab()
    {
        Console.WriteLine("=== Array-labb ===");

        string[] weekdays = ["Måndag", "Tisdag", "Onsdag", "Torsdag", "Fredag"];

        // TODO:
        // Skriv ut alla veckodagar med en for-loop.
        // Tips: använd weekdays.Length för att veta hur många element det finns.
        Console.WriteLine(
            Environment.NewLine +
            "-- for-loop --"
            );
        for(int day = 0; day < weekdays.Length; day++){
          Console.WriteLine(weekdays[day]);
        }

        // TODO:
        // Skriv ut alla veckodagar med foreach.

        Console.WriteLine(
            Environment.NewLine +
            "-- foreach-loop"
            );

        foreach(string day in weekdays){
          Console.WriteLine(day);
        }

        // Fråga 1:
        // När passar en array bättre än en List?
        Console.WriteLine(
            Environment.NewLine +
            "Svar 1:" + 
            Environment.NewLine +
            "Array passar bättre när storleken är känd och fast, t.ex veckodagar (alltid 7)." +
            "Minder overhead än List, eftersom inget behov av dynamiskt storlek."
            );

        // Fråga 2:
        // Vad händer om du försöker skriva weekdays[5]?
        Console.WriteLine(
            Environment.NewLine + 
            "Svar 2:" +
            Environment.NewLine +
            "'IndexOutOfRangeException' - arrayen har 5 element med index 0-4, så index finns inte."
            );

        // Fråga 3:
        // Varför måste arrayens storlek anges från början?
        Console.WriteLine(
            Environment.NewLine + 
            "Svar 3:" + 
            Environment.NewLine + 
            "Arrayen reserverar ett sammanhängande block i minnet vid skapande. Storleken behövs for att veta hur mycket minne som ska reserveras.");
    }

    #endregion

    #region Blandat_Stack_Heap_mm

    // ============================================================
    // DEL 6 - DICTIONARY SOM RÄKNARE
    // ============================================================

    static void WordCountLab()
    {
        Console.WriteLine("=== Dictionary-labb: räkna ord ===");

        Console.WriteLine("Skriv en mening:");
        string text = ReadLine;

        //ToDo: Skriv koden för CountWords
        Dictionary<string, int> wordCounts = CountWords(text);

        Console.WriteLine("Resultat:");

        foreach (KeyValuePair<string, int> pair in wordCounts)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }

        // Fråga:
        // Varför passar Dictionary bra när vi ska räkna ord?
        Console.WriteLine("Svar: TODO - skriv ditt svar här");
    }

    static Dictionary<string, int> CountWords(string text)
    {
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        // TODO:
        // Dela upp text i ord med string.Split.
        // Separera på: mellanslag (ett eller flera), punkt, !, ?, :, ;
        // Tips: string[] words = text.Split(new char[] { ' ', '.', '!', '?', ':', ';' },
        //                                   StringSplitOptions.RemoveEmptyEntries);
        //
        // Loopa igenom orden.
        // Gör varje ord till gemener med .ToLower() så att "Hej" och "hej" räknas som samma.
        // Om ordet redan finns i wordCounts → öka värdet med 1.
        // Annars → lägg till ordet med värdet 1.

        // Fråga:
        // Vad är nyckeln och vad är värdet i wordCounts?
        Console.WriteLine("Svar: TODO - skriv ditt svar här");

        return wordCounts;
    }

    // ============================================================
    // DEL 7 - PARENTESKONTROLL - Använd lämpliga datastrukturer
    // ============================================================

    static void ParenthesesLab()
    {
        Console.WriteLine("=== Kontrollera parenteser ===");

        // Testfall att prova:
        // ([{}])                         true
        // ({)}                           false
        // List<int> lista = new();       true
        // (]                             false
        // ((()))                         true
        // (()                            false
        // (                              false
        // )                              false
        Console.WriteLine("Skriv en kodrad eller parentessträng:");
        string input = ReadLine;

        //ToDo skriv koden för CheckParantheses
        bool isCorrect = CheckParentheses(input);

        if (isCorrect)
        {
            Console.WriteLine("Strängen är välformad.");
        }
        else
        {
            Console.WriteLine("Strängen är INTE välformad.");
        }


    }

    static bool CheckParentheses(string text)
    {
        // TODO:
        // Använd en Stack<char> och en Dictionary<char, char>.
        //
        // Tips Dictionary:
        // Låt dictionaryn mappa varje stängande parentes till sin matchande öppnare.
        // Det gör matchningskontrollen till en enkel uppslagning istället för flera if-satser.
        //
        // Tips Stack:
        // Stacken håller reda på vilka öppnare du sett men ännu inte stängt.
        // Tänk på vad LIFO innebär här — varför är det precis rätt egenskap för det här problemet?
        //
        // Fråga:
        // Varför är Dictionary + Stack bättre än bara Stack med if/else för matchningen?
        Console.WriteLine("Svar: TODO - skriv ditt svar här");

        return false;
    }

    // ============================================================
    // DEL 8 - STACKEN OCH HEAPEN
    // ============================================================

    static void MemoryLab()
    {
        Console.WriteLine("=== Value type: int ===");

        int number1 = 10;
        int number2 = number1;

        number2 = 99;

        Console.WriteLine($"number1: {number1}");
        Console.WriteLine($"number2: {number2}");

        Console.WriteLine();
        Console.WriteLine("=== Value type: struct ===");

        ScoreValue score1 = new ScoreValue(10);
        ScoreValue score2 = score1;

        score2.Points = 99;

        Console.WriteLine($"score1.Points: {score1.Points}");
        Console.WriteLine($"score2.Points: {score2.Points}");

        Console.WriteLine();
        Console.WriteLine("=== Reference type: class ===");

        ScoreReference refScore1 = new ScoreReference(10);
        ScoreReference refScore2 = refScore1;

        refScore2.Points = 99;

        Console.WriteLine($"refScore1.Points: {refScore1.Points}");
        Console.WriteLine($"refScore2.Points: {refScore2.Points}");

        Console.WriteLine();
        Console.WriteLine("=== Reference type: Product ===");

        Product product1 = new Product("KAF", "Kaffe", 15, 20);
        Product product2 = product1;

        product2.Stock = 0;

        Console.WriteLine(product1);
        Console.WriteLine(product2);

        // Fråga 1:
        // Varför ändras inte number1 när number2 ändras?
        Console.WriteLine(
            Environment.NewLine +
            "Svar 1:" + 
            Environment.NewLine +
            "'int' är en value type, så number2 får en kopia av värdet. Att ändra number2 påverkar inte number1"
            );

        // Fråga 2:
        // Varför ändras inte score1.Points när score2.Points ändras?
        Console.WriteLine(
            Environment.NewLine + 
            "Svar 2:" + 
            Environment.NewLine +
            "Struct är value type. " +
            "Eftersom, det är en kopian inte ej referens till score1"
            );

        // Fråga 3:
        // Varför ändras product1.Stock när product2.Stock ändras?
        Console.WriteLine(
           Environment.NewLine +
           "Svar 3:" + 
           Environment.NewLine +
           "Eftersom det är en referens. När man ändras product2 det som ändras i verkligheten är product1."
           );

        // Fråga 4:
        // Är Product en value type eller reference type?
        Console.WriteLine(
            Environment.NewLine +
            "Svar 4:" +
            Environment.NewLine +
            "'class' = referens type (heapen), 'struct' = value type (stacken)." +
            Environment.NewLine +
            "'Product' är en class -> alltså referencs type."
            );

        // Fråga 5:
        // Vad ligger på heapen i Product-exemplet?
        Console.WriteLine(
            Environment.NewLine + 
            "Svar 5:" + 
            "Själva Product-objektet (med alla properties) ligger på heapen.Variablerna 'product1'och 'product2' på stacken pekar dit."
            );

        // Fråga 6:
        // Vad innebär det att två variabler kan peka på samma objekt?
        Console.WriteLine(
            Environment.NewLine + 
            "Svar 6:" + 
            Environment.NewLine + 
            "Att ändra objektet via en variabel syns via alla variabler som pekar på samma objekt, eftersom det bara finns ett objekt i minnet."
            );

        // Fråga 7:
        // Vad är skillnaden mellan stacken i minnet och Stack<T> som datastruktur?
        Console.WriteLine(
            Environment.NewLine +
            "Svar 7:" +
            Environment.NewLine +
            "Stacken i minnet är en del av datorns minneshangering, hanterar metodanrop och lokala variabler automatiskt" +
            Environment.NewLine +
            "Stack<T> är en datastruktur."
            );
    }

    #endregion

    #region ExtraUppgifter


    // ============================================================
    // DEL 9 - REKURSION OCH ITERATION EXTRA om tid finns
    // ============================================================

    static void RecursionLab()
    {
        Console.WriteLine("=== Rekursion och iteration ===");

        Console.Write("Ange n: ");

        if (!int.TryParse(ReadLine, out int n))
        {
            Console.WriteLine("Du måste skriva ett heltal.");
            return;
        }

        if (n <= 0)
        {
            Console.WriteLine("n måste vara större än 0.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine($"RecursiveOdd({n}) = {RecursiveOdd(n)}");

        // TODO:
        // När du har implementerat metoderna nedan kan du avkommentera raderna.

        // Console.WriteLine($"RecursiveEven({n}) = {RecursiveEven(n)}");
        // Console.WriteLine($"IterativeEven({n}) = {IterativeEven(n)}");
        // Console.WriteLine($"FactorialRecursive({n}) = {FactorialRecursive(n)}");
        // Console.WriteLine($"SumRecursive({n}) = {SumRecursive(n)}");
        // Console.WriteLine($"SumIterative({n}) = {SumIterative(n)}");
        // Console.WriteLine($"FibonacciRecursive({n}) = {FibonacciRecursive(n)}");
        // Console.WriteLine($"FibonacciIterative({n}) = {FibonacciIterative(n)}");

        Console.WriteLine();
        Console.WriteLine("Trace av rekursion:");
        RecursiveOddWithTrace(n);

        Console.WriteLine();
        Console.WriteLine("Trace med indrag (visar rekursionsdjup):");
        RecursiveOddWithDepth(n, 0);

        // Fråga 1:
        // Vad är ett basfall?
        Console.WriteLine("Svar 1: TODO - skriv ditt svar här");

        // Fråga 2:
        // Varför måste en rekursiv metod ha ett basfall?
        Console.WriteLine("Svar 2: TODO - skriv ditt svar här");

        // Fråga 3:
        // Vad händer på stacken när en metod anropar sig själv?
        Console.WriteLine("Svar 3: TODO - skriv ditt svar här");

        // Fråga 4:
        // Vilken version är mest minnesvänlig: rekursion eller iteration? Varför?
        Console.WriteLine("Svar 4: TODO - skriv ditt svar här");
    }

    static int RecursiveOdd(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentException("n måste vara större än 0.");
        }

        if (n == 1)
        {
            return 1;
        }

        return RecursiveOdd(n - 1) + 2;
    }

    static int RecursiveEven(int n)
    {
        // TODO:
        // Om n <= 0, kasta ArgumentException med meddelandet "n måste vara större än 0."
        // Om n == 1, returnera 2.
        // Annars returnera RecursiveEven(n - 1) + 2.
        //
        // Exempel:
        // RecursiveEven(1) = 2
        // RecursiveEven(2) = 4
        // RecursiveEven(3) = 6

        return 0;
    }

    static int IterativeEven(int n)
    {
        // TODO:
        // Om n <= 0, kasta ArgumentException.
        // Använd en for-loop för att räkna fram det n:te jämna talet.
        //
        // Exempel:
        // IterativeEven(1) = 2
        // IterativeEven(2) = 4
        // IterativeEven(3) = 6

        return 0;
    }

    static int FactorialRecursive(int n)
    {
        // TODO:
        // Fakultet:
        // 5! = 5 * 4 * 3 * 2 * 1 = 120
        //
        // Om n < 0, kasta ArgumentException.
        // Om n == 0 eller n == 1, returnera 1.
        // Annars returnera n * FactorialRecursive(n - 1).

        return 0;
    }

    static int SumRecursive(int n)
    {
        // TODO:
        // Summera alla tal från 1 till n med rekursion.
        //
        // SumRecursive(5)
        // = 5 + 4 + 3 + 2 + 1
        // = 15

        return 0;
    }

    static int SumIterative(int n)
    {
        // TODO:
        // Summera alla tal från 1 till n med en loop.

        return 0;
    }

    static int FibonacciRecursive(int n)
    {
        // TODO:
        // Fibonacci:
        // 0, 1, 1, 2, 3, 5, 8, 13 ...
        //
        // Om n < 0, kasta ArgumentException.
        // Om n == 0, returnera 0.
        // Om n == 1, returnera 1.
        // Annars returnera FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2).

        return 0;
    }

    static int FibonacciIterative(int n)
    {
        // TODO:
        // Implementera Fibonacci med loop.
        // Denna version ska vara mer minnesvänlig än den rekursiva.

        return 0;
    }

    static int RecursiveOddWithTrace(int n)
    {
        Console.WriteLine($"Anropar RecursiveOddWithTrace({n})");

        if (n == 1)
        {
            Console.WriteLine("Basfall nått. Returnerar 1.");
            return 1;
        }

        int result = RecursiveOddWithTrace(n - 1) + 2;

        Console.WriteLine($"RecursiveOddWithTrace({n}) returnerar {result}");

        return result;
    }

    static int RecursiveOddWithDepth(int n, int depth)
    {
        string indentation = new string(' ', depth * 2);

        Console.WriteLine($"{indentation}RecursiveOddWithDepth({n})");

        // TODO:
        // Lägg till basfall: om n == 1, skriv ut med indrag att basfallet nåtts och returnera 1.
        // Annars: anropa RecursiveOddWithDepth(n - 1, depth + 1) rekursivt.
        // Spara resultatet, skriv ut med indrag vad metoden returnerar, och returnera resultatet.
        // Jämför utskriften med RecursiveOddWithTrace — vad tillför indraget?

        return 0;
    }

    // ============================================================
    // DEL 10 - FILHANTERING, EXTRA
    // ============================================================

    static void SaveLogToFile()
    {
        // TODO:
        // Kontrollera om logMessages är tom — skriv meddelande om den är det.
        // Annars: spara alla loggmeddelanden till en fil som heter "logg.txt".
        // Skriv ut hur många rader som sparades och var filen finns.
        //
        // Tips:
        // File.WriteAllLines("logg.txt", logMessages);
        // Console.WriteLine($"Sparade {logMessages.Count} rader till logg.txt");

        Console.WriteLine("TODO: Implementera SaveLogToFile.");
    }

    #endregion
}
