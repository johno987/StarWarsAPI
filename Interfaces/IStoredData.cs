
public interface IStoredData
{
    string? dataRead { get; set; }
    Root? myDeserializedData { get; set; }
    Dictionary<string, (double? Population, int? Diameter, int? SurfaceWater)> Planets { get; set; }

    void generateDictionary();
    Task getDataAndStoreIndataRead();
    void ParseData();
    void SortDataBasedOnUserInput(string userChoice);
}