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

    public static double? ParseDouble(string value)
    {
        double result;
        bool test = double.TryParse(value, out result);
        if (test)
        {
            return result;
        }
        return null;

    }
}


