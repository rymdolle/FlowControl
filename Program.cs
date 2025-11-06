
namespace FlowControl;

internal class Program
{
    public class MenuOption
    {
        public const string Exit = "0";
        public const string Cinema = "1";
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
                case MenuOption.Cinema:
                    Console.WriteLine("Ange ålder:");
                    if (int.TryParse(Console.ReadLine()!, out int age))
                    {
                        Console.WriteLine(CinemaPrice(age));
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                default:
                    PrintError("Ogiltigt val.");
                    break;
            }
        }
    }

    static void PrintMenu()
    {
        Console.WriteLine("Huvudmeny:");
        Console.WriteLine($"{MenuOption.Cinema}. Biopris");
        Console.WriteLine($"{MenuOption.Exit}. Avsluta");
    }

    static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    static string CinemaPrice(int age)
    {
        return CinemaPrice(age, out _);
    }
    static string CinemaPrice(int age, out int price)
    {
        if (age < 20)
        {
            price = 80;
            return $"Ungdomspris: {price}kr";
        }
        else if (age > 64)
        {
            price = 90;
            return $"Pensionärspris: {price}kr";
        }
        else
        {
            price = 120;
            return $"Standardpris: {price}kr";
        }
    }
}
