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
                    Console.Clear();
                    BioEnkel();
                    break;
               case "2":
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
    private static void BioEnkel()
    {
      Console.WriteLine("Bio-pris [enkel]");
    }
    private static void BioGrupp()
    {
      Console.WriteLine("Bio-pris [grupp]");
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
