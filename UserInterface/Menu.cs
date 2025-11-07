namespace FlowControl.UserInterface;

internal class Menu(string title)
{
    private string _title = title;
    private Menu? _parent = null;
    private Action<IUserInterface>? _action = null;
    private readonly List<Menu> _entries = [];

    public Menu(string title, Action<IUserInterface>? action)
        : this(title)
    {
        _action = action;
    }

    public Menu(string title, params Menu[] entries)
        : this(title)
    {
        foreach (var entry in entries)
            AddEntry(entry);
    }

    public Menu AddEntry(Menu entry)
    {
        entry._parent = this;
        _entries.Add(entry);
        return this;
    }

    public Menu? Navigate(IUserInterface ui)
    {
        // Invoke the action associated with this menu, if any
        _action?.Invoke(ui);
        if (_entries.Count == 0)
            return _parent;

        if (ui.ReadInt("Välj ett alternativ: ", out int choice, c => c >= 0 && c <= _entries.Count))
        {
            if (choice == 0)
                return _parent;
            return _entries[choice - 1];
        }
        ui.PrintError("Ogiltigt val. Försök igen.");
        return this;
    }

    public virtual void Display(IUserInterface ui)
    {
        ui.Display();
        ui.WriteLine(_title);
        if (_entries.Count == 0)
            return;
        for (int i = 0; i < _entries.Count; ++i)
        {
            ui.WriteLine($"{i+1}. {_entries[i]._title}");
        }
        ui.WriteLine("0. " + (_parent != null ? "Tillbaka" : "Avsluta"));
    }
}
