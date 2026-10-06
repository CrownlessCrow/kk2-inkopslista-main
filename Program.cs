using System.Linq.Expressions;

ShoppingList list = new ShoppingList("items.txt", 500);
list.Load();

while (true)
{
    Console.WriteLine();
    list.Print();
    Console.WriteLine();
    Console.WriteLine("1. Lägg till vara");
    Console.WriteLine("2. Ta bort vara");
    Console.WriteLine("3. Spara");
    Console.WriteLine("4. Sök vara");
    Console.WriteLine("5. Avsluta");
    Console.Write("Välj: ");

    if (!int.TryParse(Console.ReadLine(), out int choice)) //TryParse istället för Parse, så att programmt inte krasha om anv inte skriver en siffra.

    {
        Console.WriteLine("Skriva en siffra mellan 1 och 5"); //Om det inte är tal
        continue; //Om det inte är tal skickas tillbaka till meny 1-5
    }


    if (choice == 1)
    {
        Console.Write("Namn: ");
        string name = Console.ReadLine(); //Läser namnet.
        Console.Write("Pris: "); //kolla om priset är ett heltal

        if (!int.TryParse(Console.ReadLine(), out int price))    // Om priset inte är ett heltal läggs varan inte till.

        {
            Console.WriteLine("Priset måste vara ett heltal"); 
            continue; //tillbaka till menyn.
        }


        try //item kan kasta undantag om namn eller pris är ogiltig.
        {

            if (list.Add(new Item(name, price))) //add returnera false om budgeten är spräckt.
                Console.WriteLine("Varan lades till."); 
            else
            {
                Console.WriteLine($"Varan får inte plats i budget max {list.Budget} kr");
            }

        }
        catch (ArgumentOutOfRangeException ex) // Negativ pris från item.cs

        {
            Console.WriteLine(ex.Message);

        }
        catch (ArgumentException ex) // fångar tomt namn från item.cs

        {
            Console.WriteLine(ex.Message);
        }
    }

    else if (choice == 2)
    {
        Console.Write("Nummer: ");

        if (!int.TryParse(Console.ReadLine(), out int number)) // Numret måste vara ett heltal.
        {
            Console.WriteLine("Numret måste vara ett heltal");
            continue;

        }

        list.RemoveAt(number);
    }
    else if (choice == 3)
    {
        list.Save();
    }
    else if (choice == 4)
    {
        Console.Write("Namn att söka efter: ");
        string wanted = Console.ReadLine();
        Item found = list.Find(wanted);

        if (found == null)
        {
            Console.WriteLine("Varan finns inte i listan.");
        }
        else
        {
            Console.WriteLine($"Hittade: {found}");
        }
    }
    else if (choice == 5)
    {
        break;
    }
}
