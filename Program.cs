using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Scripture Memorizer";

        // Creativity: Add multiple scriptures for variety.
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, " +
                "that whoever believes in him shall not perish but have eternal life."),
            
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding; " +
                "in all your ways submit to him, and he will make your paths straight."),
            
            new Scripture(
                new Reference("2 Nephi", 2, 25),
                "Adam fell that men might be; and men are, that they might have joy.")
        };

        // Randomly select one scripture
        Random rand = new Random();
        Scripture selectedScripture = scriptures[rand.Next(scriptures.Count)];

        // Main loop
        while (true)
        {
            Console.Clear();
            selectedScripture.Display();

            // Exit if all words are hidden
            if (selectedScripture.IsFullyHidden())
            {
                Console.WriteLine("\n✅ All words are hidden. Great job!");
                break;
            }

            Console.Write("\nPress [Enter] to hide more words or type 'quit' to exit: ");
            string? input = Console.ReadLine();

            if (input?.Trim().ToLower() == "quit")
            {
                Console.WriteLine("\n👋 Thanks for using Scripture Memorizer. Goodbye!");
                break;
            }

            selectedScripture.HideRandomWords(3); // Hide 3 more words
        }
    }
}
