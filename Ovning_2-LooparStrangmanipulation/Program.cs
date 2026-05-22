public static class Menu
{
    public static void Run()
    {
        Console.WriteLine("Välkommen till Huvudmeny!");
        while (true)
        {
            Console.WriteLine("Välja mellan");
            Console.Write("(0)Anvsluta");
            string val = Console.ReadLine() ?? "";
            switch (val)
            {
                case "1":
                    Console.Clear();
                    CheckAge();
                    break;
                case "0":
                    Console.Clear();
                    Console.WriteLine("Hej då!");
                    return;
                default:
                    Console.WriteLine("Felaktig Input!");
                    break;
            }
        }
    }
    private static void CheckAge()
    {
        Console.Write("(U)ngdom eller (P)ensionär?");
        string val = Console.ReadLine() ?? "";
        switch (val)
        {
            case "u":
                Console.WriteLine("Ungdom vält");
                return;
            case "P":
                Console.WriteLine("Pensionär vält");
                return;
            default:
                Console.WriteLine("Try againg");
                break;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello from Main");

        Menu.Run();
    }

}
