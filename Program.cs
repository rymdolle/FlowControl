
namespace FlowControl;

internal class Program
{
    public class MenuOption
    {
        public const string Exit = "0";
        public const string Cinema = "1";
        public const string CinemaGroup = "2";
        public const string Repeat = "3";
        public const string ThirdWord= "4";
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
                {
                    Console.WriteLine("Ange ålder:");
                    if (int.TryParse(Console.ReadLine()!, out int age)  && age >= 0)
                    {
                        Console.WriteLine(CinemaPrice(age, out _));
                    }
                    else
                    {
                        PrintError("Ogiltig ålder.");
                    }
                    break;
                }
                case MenuOption.CinemaGroup:
                {
                    Console.WriteLine("Ange antal personer:");
                    if (int.TryParse(Console.ReadLine()!, out int count) && count > 0)
                    {
                        int totalPrice = 0;
                        for (int i = 1; i <= count; i++)
                        {
                            Console.WriteLine($"Ange ålder för person {i}:");
                            if (int.TryParse(Console.ReadLine()!, out int age) && age >= 0)
                            {
                                CinemaPrice(age, out int price);
                                totalPrice += price;
                            }
                            else
                            {
                                PrintError("Ogiltig ålder.");
                                i--; // Decrement i to repeat this iteration
                            }
                        }
                        Console.WriteLine($"Antal personer: {count}");
                        Console.WriteLine($"Totalpris för gruppen: {totalPrice}kr");
                    }
                    else
                    {
                        PrintError("Ogiltigt antal personer.");
                    }
                    break;
                }
                case MenuOption.Repeat:
                {
                    Console.WriteLine("Mata in en fras eller ett ord som ska upprepas.");
                    string phrase = Console.ReadLine() ?? string.Empty;
                    for (int i = 1; i <= 10; ++i)
                    {
                        // Use Write instead of WriteLine to keep it on the same line
                        Console.Write($"{i}. {phrase} ");
                    }
                    Console.WriteLine();
                    break;
                }
                case MenuOption.ThirdWord:
                {
                    Console.WriteLine("Mata in minst tre ord separerade med mellanslag:");
                    string phrase = Console.ReadLine() ?? string.Empty;
                    // RemoveEmptyEntries to avoid counting extra spaces as words
                    string[] words = phrase.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length >= 3)
                        Console.WriteLine($"Det tredje ordet är: {words[2]}");
                    else
                        PrintError("Fel: Frasen innehåller inte minst tre ord.");
                    break;
                }
                default:
                    PrintError("Ogiltigt val.");
                    break;
            }
        }
    }

    /// <summary>
    /// Displays the main menu options to the console.
    /// </summary>
    static void PrintMenu()
    {
        Console.WriteLine("Huvudmeny:");
        Console.WriteLine($"{MenuOption.Cinema}. Biopris (person)");
        Console.WriteLine($"{MenuOption.CinemaGroup}. Biopris (grupp)");
        Console.WriteLine($"{MenuOption.Repeat}. Upprepa");
        Console.WriteLine($"{MenuOption.ThirdWord}. Tredje ordet");
        Console.WriteLine($"{MenuOption.Exit}. Avsluta");
    }

    /// <summary>
    /// Displays an error message in red text on the console.
    /// </summary>
    /// <param name="message">The error message to display.</param>
    static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    /// <summary>
    /// Returns the cinema price based on age.
    /// </summary>
    /// <param name="age"></param>
    /// <param name="price">Ticket price out</param>
    /// <returns>String description of price</returns>
    static string CinemaPrice(int age, out int price)
    {
        if (age < 5 || age >= 100)
        {
            price = 0;
            return "Gratis!";
        }
        else if (age < 20)
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
