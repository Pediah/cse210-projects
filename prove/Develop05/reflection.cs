using System;

public class ReflectionActivity : MindfulnessActivity
{
    private static readonly string[] Prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions = {
        "Why was this experience meaningful to you?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What did you learn from this experience?",
        "How can you apply this experience to other situations?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times when you have shown strength and resilience.")
    {
    }

    public override void Run()
    {
        Random random = new Random();


        string prompt = Prompts[random.Next(Prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}\n");

        int reflectionTimePerQuestion = Duration / Questions.Length;

        for (int i = 0; i < Questions.Length; i++)
        {

            string question = Questions[i];
            Console.WriteLine($"Reflection Question: {question}");

            CountdownWithPause(reflectionTimePerQuestion);
        }

        Console.WriteLine("\nGood job! You've completed the reflection activity.");
    }

    public int GetNumberOfStages()
    {
        return Questions.Length;  
    }

    private void CountdownWithPause(int seconds)
    {
        Console.WriteLine($"\nTake {seconds} seconds to reflect...");
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rTime left: {i} seconds ");
            System.Threading.Thread.Sleep(2000); 
        }
        Console.WriteLine(); 
    }
}
