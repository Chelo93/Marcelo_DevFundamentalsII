using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

public sealed class LinuxButton : IButton
{
    private readonly string _theme = "LinuxDark";
    private bool _clicked = false;

    public void Click()
    {
        _clicked = true;
        Console.WriteLine("[LinuxButton] Button clicked!");
    }

    public string GetTheme()
    {
        return _theme;
    }

    public void Render()
    {
        Console.WriteLine($"[LinuxButton] Theme: {_theme}, Clicked: {_clicked}");
    }
}