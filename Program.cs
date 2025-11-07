using FlowControl.UserInterface;

namespace FlowControl;

internal class Program
{    static void Main(string[] args)
    {
        IUserInterface ui = new ConsoleUserInterface();
        Menu root = new("Huvudmeny:",
            new Menu("Biopris",
                new Menu("Person", CinemaTicket),
                new Menu("Grupp", CinemaGroupTicket)
            ),
            new Menu("Upprepa", RepeatInput),
            new Menu("Tredje ordet", ThirdWord)
            );

        Menu? menu = root;
        while (menu != null)
        {
            menu.Display(ui);
            menu = menu.Navigate(ui);
        }
    }

    /// <summary>
    /// Returns the cinema price based on age.
    /// </summary>
    /// <param name="age"></param>
    /// <param name="price">Ticket price out</param>
    /// <returns>String description of price</returns>
    public static string CinemaPrice(int age, out int price)
    {
        if (age < 5 || age >= 100)
        {
            price = 0;
            return $"Barn under 5 år och pensionärer över 100 år: {price}kr";
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

    public static void CinemaTicket(IUserInterface ui)
    {
        if (ui.ReadInt("Ange ålder:", out int age, (age) => age >= 0))
            ui.WriteLine(CinemaPrice(age, out _));
        else
            ui.PrintError("Ogiltig ålder.");
    }

    public static void CinemaGroupTicket(IUserInterface ui)
    {
        if (ui.ReadInt("Ange antal personer:", out int count, (count) => count > 0))
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
    }

    public static void RepeatInput(IUserInterface ui)
    {
        string phrase = ui.ReadLine("Mata in en fras eller ett ord som ska upprepas.");
        for (int i = 1; i <= 10; ++i)
        {
            // Use Write instead of WriteLine to keep it on the same line
            ui.Write($"{i}. {phrase} ");
        }
        ui.WriteLine();
    }

    public static void ThirdWord(IUserInterface ui)
    {
        string phrase = ui.ReadLine("Mata in minst tre ord separerade med mellanslag:");
        // RemoveEmptyEntries to avoid counting extra spaces as words
        string[] words = phrase.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (words.Length >= 3)
            ui.WriteLine($"Det tredje ordet är: {words[2]}");
        else
            ui.PrintError("Fel: Frasen innehåller inte minst tre ord.");
    }
}
