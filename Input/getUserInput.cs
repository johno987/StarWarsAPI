public static class getUserInput
{
    private static string? input;
    public static string getUserSelectionForSort()
    {
        while (true)
        {
            input = Console.ReadLine();
            if (!PrintMessageToUser.choices.Contains(input))
            {
                Console.WriteLine("Invalid choice");
            }
            else if(input is not null)
                return input;
        }
    }
}



