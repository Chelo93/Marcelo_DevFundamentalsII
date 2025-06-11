using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

public sealed class MacOSCheckBox : ICheckBox
{
    private bool _isChecked = false;
    private readonly string _style = "MacOSCheckBoxStyle";

    public void Check(bool isChecked)
    {
        _isChecked = isChecked;
    }

    public string GetStyle()
    {
        return _style;
    }

    public bool IsChecked()
    {
        return _isChecked;
    }

    public void Render()
    {
        Console.WriteLine($"[MacOSCheckBox] Style: {_style}, Checked: {_isChecked}");
    }
}