using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

public sealed class LinuxCheckBox : ICheckBox
{
    private bool _isChecked = false;
    private readonly string _style = "LinuxCheckBoxStyle";

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
        Console.WriteLine($"[LinuxCheckBox] Style: {_style}, Checked: {_isChecked}");
    }
}