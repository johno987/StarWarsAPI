using System.Text.Json;

public class StoredData
{
    public ReadAPIData APIreader = new ReadAPIData();
    public string? dataRead {  get; set; }
    public Root? myDeserializedData { get; set; }
    public Dictionary<string, (int? Population, int? Diameter, int? SurfaceWater)> Planets { get; set; } = new();
    public async Task getDataAndStoreIndataRead()
    {
        dataRead = await APIreader.readData(APIreader.baseURL, APIreader.RestofURL);
    }
    public void ParseData()
    {
        myDeserializedData = JsonSerializer.Deserialize<Root>(dataRead!)!;

    }
    public void generateDictionary()
    {
        if(myDeserializedData == null) return;
        foreach (var planet in myDeserializedData.results)
        {
            Planets[planet.name] = (Population: ParseInput.ParseInt(planet.Population), 
                Diameter: ParseInput.ParseInt(planet.Diameter),
                SurfaceWater: ParseInput.ParseInt(planet.SurfaceWater));
        }
    }

    public void SortDataBasedOnUserInput(string userChoice)
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
        Console.WriteLine("Press any key to close");
    }
}


