

public class Person
{
    string namn;
    string lon;

    public Person(string namn, string lon)
    {
        this.namn = namn;
        this.lon = lon;
    }

    public override string ToString()
    {
        return $"{namn} - {lon} ";
    }
}

public class Persons
{
    public List<Person> subjects = new List<Person>();

    public void AddPerson(Person person)
    {
        subjects.Add(person);
    }
    public Person Last(){
      return subjects[subjects.Count -1];
    }

    public override string ToString()
    {
        return string.Join("\n", subjects);
    }

}
public class Menu{
  public Menu(){
    // Constructutor
  }

  public override string ToString(){
    return "this is meny class.";
  }
 // metoder 
 //
public void Add(Persons personer){
  Console.Clear();
  Console.WriteLine("menyval add Person"); 
  Console.WriteLine("Sriv namn: ");
  string namn = Console.ReadLine();
  Console.WriteLine("Skriv lön: ");
  string lon = Console.ReadLine();
  personer.AddPerson(new Person(namn, lon));
  Console.Clear();
  Console.WriteLine($"{personer.Last()}  , added"); 
} 
public void List(Persons personer){
  Console.Clear();
  Console.WriteLine("List anställda: ")
  Console.WriteLine(personer);
}

}
class Program
{
    public static void Main()
    {
        Persons personer = new Persons();
        // personer.AddPerson(new Person("Javier", "5000"));
        // Console.WriteLine(personer);

        Menu menu = new Menu();

while (true)
{
  Console.Clear();
        Console.WriteLine("Välja mellan (A)ddera anställd, (L)ista anställda, (O)ut program");

        string val = Console.ReadLine().ToLower();
            switch (val){
          case "a":
            Console.WriteLine("Addera anställda");
            menu.Add(personer);
            Console.WriteLine("Tryck Enter för att fortsätta...");
            Console.ReadLine();
            break;
          case "l":
            Console.WriteLine("Lista anställda");
            menu.List(personer);
            Console.WriteLine("Tryck Enter för att fortsätta...");
            Console.ReadLine();
            break;
          case  "o":
            Console.Clear();
            Console.WriteLine("Hej då!");
            return; // avslutar Main;
          default:
               Console.WriteLine("Skviv rätt  menyval");
            Thread.Sleep(1000);
               break;
        }
}
} 
} 
