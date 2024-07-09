public static class ParseInput
{
    public static int? ParseInt(string value)
    {
        int result;
        bool test = Int32.TryParse(value, out result);
        if (test)
        {
            return result;
        }
        return null;

    }
}


