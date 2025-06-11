using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

public sealed class WindowsTextBox : ITextBox
{
    private string _text = string.Empty;
    private readonly string _font = "Segoe UI";

    public string GetFont()
    {
        return _font;
    }

    public string GetText()
    {
        return _text;
    }

    public void Render()
    {
        Console.WriteLine($"[WindowsTextBox] Font: {_font}, Text: {_text}");
    }

    public void SetText(string text)
    {
        _text = text;
    }
}