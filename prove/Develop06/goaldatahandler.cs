using System;
using System.Collections.Generic;
using System.IO;

public static class GoalDataHandler
{
    public static void SaveData(User user, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(user.GetScore()); // Save score first
            foreach (Goal goal in user.GetGoals())
            {
                writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Description}|{goal.Points}|{goal.IsCompleted}|{goal.GetStatus()}");
            }
        }
    }

    public static User LoadData(string filePath)
    {
        User user = new User();
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                if (int.TryParse(reader.ReadLine(), out int score))
                {
                    user.SetScore(score); // Load saved score
                }

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 5)
                    {
                        string goalType = parts[0];
                        string name = parts[1];
                        string description = parts[2];
                        int points = int.Parse(parts[3]);
                        bool isCompleted = bool.Parse(parts[4]);

                        Goal goal = goalType switch
                        {
                            "SimpleGoal" => new SimpleGoal(name, description, points),
                            "EternalGoal" => new EternalGoal(name, description, points),
                            "ChecklistGoal" when parts.Length >= 7 =>
                                new ChecklistGoal(name, description, points, int.Parse(parts[5]), int.Parse(parts[6])),
                            _ => null
                        };

                        if (goal != null)
                        {
                            if (isCompleted)
                            {
                                goal.RecordEvent(); // Mark as completed if needed
                            }
                            user.AddGoal(goal);
                        }
                    }
                }
            }
        }
        return user;
    }
}
