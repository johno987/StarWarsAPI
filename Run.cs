using System.Net.Security;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Run
{
    public static StoredData data = new();
    public static async Task Main()
    {
        await data.getDataAndStoreIndataRead(); //we must await the read otherwise, dataRead will be null
        data.ParseData();
        PrintMessageToUser.printData(data.myDeserializedData);
        data.generateDictionary();
        PrintMessageToUser.printUserQuestion();
        var input = getUserInput.getUserSelectionForSort(); ;
        data.findData(input);
        Console.ReadKey();
    }
}

