using FlowControl.UserInterface;

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
        IUserInterface ui = new ConsoleUserInterface();
        while (true)
        {
            ui.Display();
            string input = ui.ReadLine("Välj ett alternativ:");
            switch (input)
            {
                case MenuOption.Exit:
                    return;
                case MenuOption.Cinema:
                {
                    if (ui.ReadInt("Ange ålder:", out int age, (age) => age >= 0))
                        ui.WriteLine(CinemaPrice(age, out _));
                    else
                        ui.PrintError("Ogiltig ålder.");
                    break;
                }
                case MenuOption.CinemaGroup:
                {
                    if (ui.ReadInt("Ange antal personer:", out int count,  (count) => count > 0))
                    {
                        int totalPrice = 0;
                        for (int i = 1; i <= count; i++)
                        {
                            if (ui.ReadInt($"Ange ålder för person {i}:", out int age, (age) => age >= 0))
                            {
                                CinemaPrice(age, out int price);
                                totalPrice += price;
                            }
                            else
                            {
                                ui.PrintError("Ogiltig ålder.");
                                i--; // Decrement i to repeat this iteration
                            }
                        }
                        ui.WriteLine($"Antal personer: {count}");
                        ui.WriteLine($"Totalpris för gruppen: {totalPrice}kr");
                    }
                    else
                    {
                        ui.PrintError("Ogiltigt antal personer.");
                    }
                    break;
                }
                case MenuOption.Repeat:
                {
                    string phrase = ui.ReadLine("Mata in en fras eller ett ord som ska upprepas.");
                    for (int i = 1; i <= 10; ++i)
                    {
                        // Use Write instead of WriteLine to keep it on the same line
                        ui.Write($"{i}. {phrase} ");
                    }
                    ui.WriteLine();
                    break;
                }
                case MenuOption.ThirdWord:
                {
                    string phrase = ui.ReadLine("Mata in minst tre ord separerade med mellanslag:");
                    // RemoveEmptyEntries to avoid counting extra spaces as words
                    string[] words = phrase.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length >= 3)
                        ui.WriteLine($"Det tredje ordet är: {words[2]}");
                    else
                        ui.PrintError("Fel: Frasen innehåller inte minst tre ord.");
                    break;
                }
                default:
                    ui.PrintError("Ogiltigt val.");
                    break;
            }
        }
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
