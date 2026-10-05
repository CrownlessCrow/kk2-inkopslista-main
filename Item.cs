// One item on the shopping list.
class Item
{
    public string Name { get; set; }
    public int Price { get; set; }

    public Item(string name, int price)
    {
        if (string.IsNullOrWhiteSpace(name)) // Tillåter inte tom sträng eller mellanslag.

        {
            throw new ArgumentException ("Namnet får inte vara tomt.");
        }

        if (price < 0) //Negativpris inte tillåtet
        {
            throw new ArgumentOutOfRangeException(null, "Priset får inte vara negativt"); //null ? inget parameternamn, felet kasta till try/tach i Program.cs
        }



//Båda villkoren uppfyllda då sparas väderna i varan.
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} - {Price} kr";
    }
}
