
public interface IReadAPIData
{
    Task<string> readData(string URI, string URL = "");
}