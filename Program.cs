namespace FlowControl;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            PrintMenu();
            string input = Console.ReadLine() ?? string.Empty;
            switch (input)
            {
                case "0":
                    return;
                default:
                    PrintError("Invalid option.");
                    break;
            }
        }
    }

    static void PrintMenu()
    {
        Console.WriteLine("Main menu:");
        Console.WriteLine("0. Exit");
    }

    static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
