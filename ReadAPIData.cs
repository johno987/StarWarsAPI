using System.Data.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ReadAPIData : IReadAPIData
{
    private readonly string BaseURL = "https://swapi.dev/api/";
    private readonly string restofURL = "planets";
    HttpClient Client = new HttpClient();

    string IReadAPIData.baseURL{  get => BaseURL; }
    string IReadAPIData.RestofURL{ get => restofURL;}

    public async Task<string> readData(string baseAddress, string URI = "")
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseAddress);
        var response = await client.GetAsync(URI);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}


