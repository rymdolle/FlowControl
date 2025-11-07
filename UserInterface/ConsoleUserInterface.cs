using static FlowControl.Program;

namespace FlowControl.UserInterface;

internal class ConsoleUserInterface : IUserInterface
{
    public void Display()
    {
        Console.WriteLine("Huvudmeny:");
        Console.WriteLine($"{MenuOption.Cinema}. Biopris (person)");
        Console.WriteLine($"{MenuOption.CinemaGroup}. Biopris (grupp)");
        Console.WriteLine($"{MenuOption.Repeat}. Upprepa");
        Console.WriteLine($"{MenuOption.ThirdWord}. Tredje ordet");
        Console.WriteLine($"{MenuOption.Exit}. Avsluta");
    }

    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public void Write(string message)
    {
        Console.Write(message);
    }

    public void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public bool ReadInt(string prompt, out int result, Predicate<int> constraint)
    {
        string input = ReadLine(prompt);
        if (int.TryParse(input, out result))
        {
            return constraint(result);
        }
        return false;
    }

    public string ReadLine(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine() ?? string.Empty;
    }
}
