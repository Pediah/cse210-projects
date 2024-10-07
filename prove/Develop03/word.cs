using System;

public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    // Method to hide the word
    public void Hide()
    {
        IsHidden = true;
    }

    // Display the word, or a placeholder if it's hidden
    public override string ToString()
    {
        return IsHidden ? "____" : Text;
    }
}
