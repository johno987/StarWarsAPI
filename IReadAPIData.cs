
public interface IReadAPIData
{
    Task<string> readData(string URI, string URL = "");
    public const string baseURL = "https://swapi.dev/api/";
    public const string RestofURL = "planets";
}