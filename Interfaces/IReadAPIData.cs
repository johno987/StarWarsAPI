
public interface IReadAPIData
{
    Task<string> readData(string baseAddress, string URI = "");
    public string baseURL { get; }
    public string RestofURL { get; }
}