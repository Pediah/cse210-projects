using System;

public class Journal
{
    private Entry[] entries = new Entry[100]; // Array to hold journal entries
    private int entryCount = 0; // To keep track of the number of entries

    // Method to add a new entry to the journal
    public void AddEntry(string prompt, string response)
    {
        if (entryCount < entries.Length)
        {
            entries[entryCount] = new Entry(prompt, response); // Create and add the new entry
            entryCount++; // Increment the entry count
        }
        else
        {
            Console.WriteLine("Journal is full, cannot add more entries.");
        }
    }


    public void DisplayEntries()
    {
        for (int i = 0; i < entryCount; i++)
        {
            Console.WriteLine(entries[i]);
            Console.WriteLine();
        }
    }

 
    public void SaveToFile(string filename)
    {
        string[] lines = new string[entryCount];
        for (int i = 0; i < entryCount; i++)
        {
            lines[i] = entries[i].ToString(); 
        }
        System.IO.File.WriteAllLines(filename, lines);
    }


    public void LoadFromFile(string filename)
    {
        if (System.IO.File.Exists(filename))
        {
            string[] loadedLines = System.IO.File.ReadAllLines(filename);
            foreach (var line in loadedLines)
            {
               
                var parts = line.Split(new[] { " - " }, 2, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    string dateString = parts[0];
                    string promptAndResponse = parts[1];
                    string[] promptResponseParts = promptAndResponse.Split(new[] { "\n" }, 2, StringSplitOptions.None);

                    if (promptResponseParts.Length == 2)
                    {
                        string prompt = promptResponseParts[0];
                        string response = promptResponseParts[1];

                        AddEntry(prompt, response);
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
