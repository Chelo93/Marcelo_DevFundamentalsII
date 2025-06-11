using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

public sealed class MacOSTextBox : ITextBox
{
    private string _text = string.Empty;
    private readonly string _font = "San Francisco";

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
        Console.WriteLine($"[MacOSTextBox] Font: {_font}, Text: {_text}");
    }

    public void SetText(string text)
    {
        _text = text;
    }
}