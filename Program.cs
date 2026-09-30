ShoppingList list = new ShoppingList("items.txt");
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
        string name = Console.ReadLine();
        Console.Write("Pris: ");

        if (!int.TryParse(Console.ReadLine(), out int price))    // Om priset inte är ett heltal läggs varan inte till.

        {
            Console.WriteLine("Priset måste vara ett heltal");
            continue;
        }


        list.Add(new Item(name, price));
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
