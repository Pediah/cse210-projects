using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user for reference details
        Console.Write("Enter the book name: ");
        string book = Console.ReadLine();

        Console.Write("Enter the chapter number: ");
        int chapter = int.Parse(Console.ReadLine());

        Console.Write("Enter the verse number: ");
        int verse = int.Parse(Console.ReadLine());

        Reference reference = new Reference(book, chapter, verse);

        // Prompt the user for the scripture text
        Console.Write("Enter the scripture text: ");
        string scriptureText = Console.ReadLine();

        Scripture scripture = new Scripture(reference, scriptureText);

        while (true)
        {
            scripture.Display();
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");

            // Get user input
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideWords(3);

            if (scripture.AllWordsHidden())
            {
                scripture.Display();
                Console.WriteLine("Congratulations! You've successfully memorized the scripture.");
                break;
            }
        }

        Console.WriteLine("Thank you!");
    }
}
