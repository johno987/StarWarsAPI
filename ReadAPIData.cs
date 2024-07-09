using System.Data.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ReadAPIData
{
    public readonly string baseURL = "https://swapi.dev/api/";
    public readonly string RestofURL = "planets";
    HttpClient Client = new HttpClient();

    public async Task<string> readData(string baseAddress, string URI = "")
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseAddress);
        var response = await client.GetAsync(URI);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}


