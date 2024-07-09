using System.Net.Security;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Run
{
    public static StoredData data = new();
    public static async Task Main()
    {
        await data.getDataAndStoreIndataRead(); //reads the json string from the API
        data.ParseData(); //parses the json string into our record variable
        PrintMessageToUser.printData(data.myDeserializedData!); //prints the API data (planet, population, diameter & water)
        //UniversalPrinter.printTable(data.myDeserializedData);
        data.generateDictionary(); //parses the data into a dictionary for easy handling
        PrintMessageToUser.printUserQuestion();
        var input = getUserInput.getUserSelectionForSort();
        data.SortDataBasedOnUserInput(input); //sorts & prints data as requested by user
        Console.ReadKey();
    }
}

