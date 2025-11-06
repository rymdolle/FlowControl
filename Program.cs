namespace FlowControl;

internal class Program
{
    public class MenuOption
    {
        public const string Exit = "0";
    }

    static void Main(string[] args)
    {
        while (true)
        {
            PrintMenu();
            string input = Console.ReadLine() ?? string.Empty;
            switch (input)
            {
                case MenuOption.Exit:
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
        Console.WriteLine($"{MenuOption.Exit}. Exit");
    }

    static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
