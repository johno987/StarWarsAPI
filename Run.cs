using System.Net.Security;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Run
{
    const string baseURL = "https://swapi.dev/api/";
    const string RestofURL = "planets";
    static string[] choices = ["Population", "Diameter", "Surface Water"];
    public static IReadAPIData APIreader = new ReadAPIData();
    public static string? dataRead { get; set; }
    public static Root? myDeserializedData { get; set; }
    public static Type? objectType { get; set; }
    public static Dictionary<string?, (int? Population, int? Diameter, int? SurfaceWater)> Planets { get; set; } = new();
    public static async Task Main()
    {
        await getDataAndStoreIndataRead(); //we must await the read otherwise, dataRead will be null
        ParseData();
        printData();
        generateDictionary();
        printUserQuestion();
        var input = getUserInput();
        findData(input);

        //UniversalPrinter.printTable(myDeserializedData.results);

        Console.ReadKey();
    }
    private static async Task getDataAndStoreIndataRead()
    {
        dataRead = await APIreader.readData(baseURL, RestofURL);
    }

    private static void ParseData()
    {
        myDeserializedData = JsonSerializer.Deserialize<Root>(dataRead!)!;

    }
    private static void printData()
    {
        foreach (var item in myDeserializedData.results)
        {
            Console.WriteLine($"Planet {item.name,-10} Population {item.population,-15} Diameter {item.diameter,-10}" +
                $"Surface Water {item.surface_water,-10}");
        }
    }
    private static void generateDictionary()
    {
        foreach (var planet in myDeserializedData.results)
        {
            Planets[planet.name] = (Population: ParseInt(planet.population), Diameter: ParseInt(planet.diameter),
                SurfaceWater: ParseInt(planet.surface_water));
        }
    }
    private static void printUserQuestion()
    {
        Console.WriteLine("\nThe statistics of which property would you like to see?");
        foreach (var choice in choices)
        {
            Console.WriteLine(choice);
        }
    }
    private static string getUserInput()
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (!choices.Contains(input))
            {
                Console.WriteLine("Invalid choice");
            }
            else
                return input;
        }
    }
    private static void findData(string userChoice) //this works, just needs refactoring now
    {
        switch (userChoice)
        {
            case "Population":
                var sortedByPopulation = Planets.OrderBy(p => p.Value.Population).Where(p => p.Value.Population != null).ToList();
                var highestPopulation = sortedByPopulation.Last();
                var LowestPopulation = sortedByPopulation.First();
                Console.WriteLine($"Planet with Highest Population {highestPopulation.Key} with a value of {highestPopulation.Value.Population}\nPlanet with the lowest Pop" +
        $"ulation {LowestPopulation.Key} with a population of {LowestPopulation.Value.Population} ");
                break;
            case "Diameter":
                var sortedByDiameter = Planets.OrderBy(p => p.Value.Diameter).Where(p => p.Value.Diameter != null).ToList();
                var highestDiameter = sortedByDiameter.Last();
                var lowestDiameter = sortedByDiameter.First();
                Console.WriteLine($"Planet with Highest Diameter {highestDiameter.Key} with a value of {highestDiameter.Value.Diameter}\nPlanet with the lowest Diameter" +
        $" {lowestDiameter.Key} with a Diameter of {lowestDiameter.Value.Diameter} ");
                break;
            case "Surface Water":
                var sortedByWater = Planets.OrderBy(p => p.Value.SurfaceWater).Where(p => p.Value.SurfaceWater != null).ToList();
                var highsetWater = sortedByWater.Last();
                var lowestWater = sortedByWater.First();
                Console.WriteLine($"Planet with Highest Water {highsetWater.Key} with a value of {highsetWater.Value.SurfaceWater}\nPlanet with the lowest Water" +
        $" {lowestWater.Key} with a Water of {lowestWater.Value.SurfaceWater} ");
                break;
            default:
                Console.WriteLine("Not a valid choice");
                break;
        }
    }
    private static int? ParseInt(string value)
    {
        int result;
        bool test = Int32.TryParse(value, out result);
        if (test)
        {
            return result;
        }
        return null;

    }

}












public record Result(
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("rotation_period")] string rotation_period,
    [property: JsonPropertyName("orbital_period")] string orbital_period,
    [property: JsonPropertyName("diameter")] string diameter,
    [property: JsonPropertyName("climate")] string climate,
    [property: JsonPropertyName("gravity")] string gravity,
    [property: JsonPropertyName("terrain")] string terrain,
    [property: JsonPropertyName("surface_water")] string surface_water,
    [property: JsonPropertyName("population")] string population,
    [property: JsonPropertyName("residents")] IReadOnlyList<string> residents,
    [property: JsonPropertyName("films")] IReadOnlyList<string> films,
    [property: JsonPropertyName("created")] DateTime created,
    [property: JsonPropertyName("edited")] DateTime edited,
    [property: JsonPropertyName("url")] string url
);

public record Root(
    [property: JsonPropertyName("count")] int count,
    [property: JsonPropertyName("next")] string next,
    [property: JsonPropertyName("previous")] object previous,
    [property: JsonPropertyName("results")] IReadOnlyList<Result> results
);

