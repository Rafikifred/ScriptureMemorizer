using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] splitWords = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var w in splitWords)
        {
            _words.Add(new Word(w));
        }
    }

    public void Display()
    {
        Console.WriteLine(_reference.ToString());
        foreach (var word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine("\n");
    }

    public void HideRandomWords(int count)
    {
        var notHiddenWords = _words.FindAll(w => !w.IsHidden);
        int hideCount = Math.Min(count, notHiddenWords.Count);

        for (int i = 0; i < hideCount; i++)
        {
            int index = _random.Next(notHiddenWords.Count);
            notHiddenWords[index].Hide();
            notHiddenWords.RemoveAt(index);  // avoid hiding same word twice this turn
        }
    }

    public bool IsFullyHidden()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden)
                return false;
        }
        return true;
    }
}
