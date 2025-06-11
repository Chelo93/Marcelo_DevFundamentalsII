using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

public sealed class MacOSButton : IButton
{
    private readonly string _theme = "MacOSLight";
    private bool _clicked = false;

    public void Click()
    {
        _clicked = true;
        Console.WriteLine("[MacOSButton] Button clicked!");
    }

    public string GetTheme()
    {
        return _theme;
    }

    public void Render()
    {
        Console.WriteLine($"[MacOSButton] Theme: {_theme}, Clicked: {_clicked}");
    }
}