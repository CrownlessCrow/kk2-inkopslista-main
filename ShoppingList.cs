// Holds the items and takes care of loading and saving them.
using System.Data.Common;
using System.Linq.Expressions;

class ShoppingList
{
    private List<Item> items = new List<Item>();
    private string path;

    public ShoppingList(string path)
    {
        this.path = path;
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    // Removes the item the user sees as number 1, 2, 3 ...
    public void RemoveAt(int number)
    {
        if (number < 1 || number > items.Count) // kontrollera att numret finns i listan, annars krashar item.RemoveAt om man anger högre belopp än listan.

        {
            Console.WriteLine("Det finns ingen vara med det numret");
            return; //avbryter metoden utan att ta bort något
        }


        items.RemoveAt(number - 1); // indexet från litsan är 0, användaren är 1 så lägger till -1 för anpassar.

    }

    // Adds up the price of every item on the list.
    public int Total()
    {
        int sum = 0;

        for (int i = 0; i < items.Count; i++)  // Börjar på 0 eftersom listan börja på index 0.
        {
            sum += items[i].Price;
        }

        return sum;
    }

    // Looks up an item by its name. Returns null if there is no such item.
    public Item Find(string name)
    {
        foreach (Item item in items)
        {
            if (item.Name == name)
            {
                return item;
            }
        }

        return null;
    }

    public void Print()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }

        Console.WriteLine($"Totalt: {Total()} kr");
    }

    // Writes one item per line, as "price;name".
    public void Save()
    {
        List<string> lines = new List<string>();

        foreach (Item item in items)
        {
            lines.Add($"{item.Price};{item.Name}");
        }

        try
        {
            File.WriteAllText(path, string.Join("\r\n", lines) + "\r\n");
            Console.WriteLine("Listan är sparad."); //Skriver ut bara om sparningen lyckades.
        }
        catch (UnauthorizedAccessException) //fångar felfil om den är skrivskyddad.
        {
            Console.WriteLine("Kunde inte spara listan"); //säger till användaren att den inte gick att spara
        }


    }

    // läser in filen till listan igen.
    public void Load()
    {
        string[] lines; // skapas utanför try så att foreach längre ner kan använda den   

        try
        {
            lines = File.ReadAllLines(path); //läser filen rad för rad, då jag tog bort radbrytningen för \r \n

        }
        catch (FileNotFoundException) //fångar bara felet, alltså "filen som inte finns"

        {
            Console.WriteLine("Hittade ingen sparad lista, statar med en tom lista");
            return; // avbryter Load, programmet start emd en tom lista.
        }

        foreach (string line in lines)
        {

            string[] parts = line.Split(';'); //Dela på raden vid ; till exempel 15;Mjöl blir 2 parts "15" och "mjölk"
            if (parts.Length != 2) //Om raden inte har exakt 2 bitar (exempel på items.txt rad 4 är tom då rad 4 räknas som part[0])

            {
                continue;  //Hoppa över raden, då den läggs inte till.
            }

            items.Add(new Item(parts[1], int.Parse(parts[0]))); //Raden har 2 bitar, så varan läggs till. Alltså behöver part [0] och [1] för den ska köra annars krash.
        }
    }
}
