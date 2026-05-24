public static class Menu
{
    public static void Run()
    {
        Console.WriteLine("Välkommen till Applicationer!");
        while (true)
        {
            Console.WriteLine("Välja mellan");
            Console.Write("(0)Anvsluta, (1)Bio-pris[enkel], (2)Bio-pris[grupp], (3)Upprepa text, (4)Tredje Ordet: ");
            string val = (Console.ReadLine() ?? "").ToLower();
            switch (val)
            {
                 case "0":
                    Console.Clear();
                    Console.WriteLine("Hej då!");
                    return;
                case "1":
      Console.WriteLine("Bio-pris [enkel]");
                    Console.Clear();
                    BioEnkel();
                    break;
               case "2":
      Console.WriteLine("Bio-pris [grupp]");
                    Console.Clear();
                    BioGrupp();
                    break;
               case "3":
                    Console.Clear();
                    UpprepaText();
                    break;
               case "4":
                    Console.Clear();
                    TredjeOrdet();
                    break;
               default:
                    Console.Clear();
                    Console.WriteLine("Felaktig Input!");
                    break;
            }
        }

    }
    private static int BioEnkel()
    {
      // Lagring
      int pris = 0;

      // Logic
      while (true)
      {
        Console.Write("Ange ålder: ");
        if (int.TryParse(Console.ReadLine(), out int age))   {
          Console.WriteLine($"Ålder: {age}");
          if (age < 20){
          pris = 80;
            Console.WriteLine($"Ungdomspris: {pris}kr");
          }else if (age < 65)
          {
            pris = 120;
             Console.WriteLine($"Standardpris: {pris}kr");
          } else
          {
            pris = 90;
              Console.WriteLine($"Pensinärspris: {pris}kr");
          }

          return pris;
        }
        Console.Clear();
        Console.WriteLine("Felaktig inmatning! Försök igen!");
      }
    }
    private static void BioGrupp()
    {
     // Lagring 
      List<int> amounts = new();
      int total = 0;

      // Logic

      while (true){
      Console.WriteLine("Hur många personer i sällskapet?: ");
      if (int.TryParse(Console.ReadLine(), out int nPersons))
      {
        for (int i = 0; i < nPersons; i++)
        {
           amounts.Add(BioEnkel()); 
           total = amounts.Sum();
        }
           Console.WriteLine($"Total personer: {nPersons}\nTotalkostnad: {total}");
         return;
      }
      Console.WriteLine("Felaktig inmatning! Måste vara en heltal.\n Försök igen!");
      }
    }
    private static void TredjeOrdet()
    {
      Console.WriteLine("Tredje Ordet");
    }
    private static void UpprepaText()
    {
      Console.WriteLine("Upprepa Text");
    }




}

class Program
{
    static void Main(string[] args)
    {
        Menu.Run();
    }

}
