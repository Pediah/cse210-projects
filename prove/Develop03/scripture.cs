using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] splitWords = text.Split(' ');
        foreach (var word in splitWords)
        {
            _words.Add(new Word(word));
        }
    }

    // Display the scripture with hidden words
    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference.ToString());
        foreach (Word word in _words)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }

    // Hide a few random words
    public void HideWords(int numberToHide)
    {
        int hiddenCount = 0;
        List<int> unhiddenIndexes = new List<int>();

        // Get indexes of all unhidden words
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden)
            {
                unhiddenIndexes.Add(i);
            }
        }

        // If fewer unhidden words than number to hide, adjust the count
        numberToHide = Math.Min(numberToHide, unhiddenIndexes.Count);

        // Hide random words from the unhidden ones
        while (hiddenCount < numberToHide && unhiddenIndexes.Count > 0)
        {
            int randomIndex = _random.Next(unhiddenIndexes.Count);
            int wordIndex = unhiddenIndexes[randomIndex];

            _words[wordIndex].Hide();
            unhiddenIndexes.RemoveAt(randomIndex); // Remove from the list once hidden
            hiddenCount++;
        }
    }

    // Check if all words are hidden
    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden)
            {
                return false;
            }
        }
        return true;
    }
}
