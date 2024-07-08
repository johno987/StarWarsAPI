public class ReadAPIData : IReadAPIData
{
    HttpClient Client = new HttpClient();
    HttpResponseMessage responseMessage;
    public async Task<string> readData(string baseAddress, string URI = "")
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseAddress);
        var response = await client.GetAsync(URI);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}