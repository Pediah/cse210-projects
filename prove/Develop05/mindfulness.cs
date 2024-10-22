using System;

public class MindfulnessActivity
{
    public string ActivityName { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }  

    public MindfulnessActivity(string name, string description)
    {
        ActivityName = name;
        Description = description;
    }

    public virtual void Start()
    {
        Console.WriteLine($"Starting {ActivityName}...");
        Console.WriteLine(Description);

        if (this is ReflectionActivity)
        {

            Console.Write("Enter the reflection time for each stage (in seconds): ");
            int promptTime = int.Parse(Console.ReadLine());
            int stages = ((ReflectionActivity)this).GetNumberOfStages();  
            Duration = promptTime * stages;  

            Console.WriteLine($"Total reflection time will be: {Duration} seconds.");
        }
        else
        {
            Console.Write("Enter the duration (in seconds): ");
            Duration = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Prepare to begin...");
        Pause(3);  
    }

    public virtual void Run()
    {
        
    }

    public void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rStarting in: {i} seconds...");
            System.Threading.Thread.Sleep(1000); 
        }
        Console.WriteLine();
    }
}
