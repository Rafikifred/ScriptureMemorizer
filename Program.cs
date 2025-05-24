using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: multiple scriptures can be added here for random choice.
        var scriptures = new Scripture[]
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, " +
                "that whoever believes in him shall not perish but have eternal life."),
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding; " +
                "in all your ways submit to him, and he will make your paths straight.")
        };

        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Length)];

        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.IsFullyHidden())
            {
                Console.WriteLine("All words are hidden. Well done!");
                break;
            }

            Console.Write("Press Enter to hide words or type 'quit' to exit: ");
            string? input = Console.ReadLine();

            if (input?.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}
