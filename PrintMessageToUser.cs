public static class PrintMessageToUser
{
    public static string[] choices = ["Population", "Diameter", "Surface Water"];
    public static void printData(Root myDeserializedData)
    {
        foreach (var item in myDeserializedData.results)
        {
            Console.WriteLine($"Planet {item.name,-10} Population {item.Population,-15} Diameter {item.Diameter,-10}" +
                $"Surface Water {item.SurfaceWater,-10}");
        }
    }
    public static void printUserQuestion()
    {
        Console.WriteLine("\nThe statistics of which property would you like to see?");
        foreach (var choice in choices)
        {
            Console.WriteLine(choice);
        }
    }
}



