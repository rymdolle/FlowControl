namespace FlowControl.UserInterface;

internal class ConsoleUserInterface : IUserInterface
{

    public void Display()
    {
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
