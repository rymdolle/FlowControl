namespace FlowControl.UserInterface;

internal interface IUserInterface
{
    /// <summary>
    /// Displays the main menu options to the console.
    /// </summary>
    void Display();
    
    /// <summary>
    /// Prints a message to the console.
    /// </summary>
    /// <param name="message"></param>
    void WriteLine(string message = "");
    
    /// <summary>
    /// Prints a message to the console without a newline.
    /// </summary>
    /// <param name="message"></param>
    void Write(string message);

    /// <summary>
    /// Displays an error message in red text on the console.
    /// </summary>
    /// <param name="message">The error message to display.</param>
    void PrintError(string message);

    /// <summary>
    /// Read a line of input from the user with a prompt.
    /// </summary>
    /// <param name="prompt"></param>
    /// <returns>Result</returns>
    string ReadLine(string prompt = "");

    /// <summary>
    /// Read integer input from the user with a prompt and validate it against a constraint.
    /// </summary>
    /// <param name="prompt"></param>
    /// <param name="result"></param>
    /// <param name="constraint"></param>
    /// <returns>True if an integer is read and pass the constraint, otherwise false.</returns>
    bool ReadInt(string prompt, out int result, Predicate<int> constraint);
}
