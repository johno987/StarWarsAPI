using System.Net.Security;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

var StartCode = new Run(new StoredData(new ReadAPIData()));
await StartCode.RunCode();

public class Run
{
    private IStoredData? data;

    public Run(IStoredData Data)
    {
        data = Data;
    }
    public async Task RunCode()
    {
        //data = new StoredData();
        await data.getDataAndStoreIndataRead(); //reads the json string from the API
        data.ParseData(); //parses the json string into our record variable
        //PrintMessageToUser.printData(data.myDeserializedData!); //prints the API data (planet, population, diameter & water)
        UniversalPrinter.magicPrint(data.myDeserializedData.results.ToList());
        data.generateDictionary(); //parses the data into a dictionary for easy handling
        PrintMessageToUser.printUserQuestion();
        var input = getUserInput.getUserSelectionForSort();
        data.SortDataBasedOnUserInput(input); //sorts & prints data as requested by user
        Console.ReadKey();
    }
}

