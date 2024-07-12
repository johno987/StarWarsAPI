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
            Planets[planet.Name] = 
                (Population: ParseInput.ParseInt(planet.Population), 
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
                Console.WriteLine($"Max {userChoice} is {highestPopulation.Value.Population} (planet: {highestPopulation.Key})\n" +
                    $"Min {userChoice} is {LowestPopulation.Value.Population} (planet: {LowestPopulation.Key})");
                break;
            case "Diameter":
                var sortedByDiameter = Planets.OrderBy(p => p.Value.Diameter).Where(p => p.Value.Diameter != null).ToList();
                var highestDiameter = sortedByDiameter.Last();
                var lowestDiameter = sortedByDiameter.First();
                Console.WriteLine($"Max {userChoice} is {highestDiameter.Value.Diameter} (planet: {highestDiameter.Key})\n" +
                    $"Min {userChoice} is {lowestDiameter.Value.Diameter} (planet: {lowestDiameter.Key})");
                break;
            case "Surface Water":
                var sortedByWater = Planets.OrderBy(p => p.Value.SurfaceWater).Where(p => p.Value.SurfaceWater != null).ToList();
                var highsetWater = sortedByWater.Last();
                var lowestWater = sortedByWater.First();
                Console.WriteLine($"Max {userChoice} is {highsetWater.Value.SurfaceWater} (planet: {highsetWater.Key})\n" +
                    $"Min {userChoice} is {lowestWater.Value.SurfaceWater} (planet: {lowestWater.Key})");
                break;
            default:
                Console.WriteLine("Not a valid choice");
                break;
        }
        Console.WriteLine("Press any key to close");
    }
}


