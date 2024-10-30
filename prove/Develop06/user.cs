using System;
using System.Collections.Generic;

public class User
{
    private int _score;
    private List<Goal> _goals;

    public User()
    {
        _score = 0;
        _goals = new List<Goal>();
    }

    public void AddGoal(Goal goal) => _goals.Add(goal);
    public List<Goal> GetGoals() => _goals; // Used for saving goals
    public int GetScore() => _score;

    public void SetScore(int score) => _score = score; // Set score for loading

    public void RecordEvent(string goalName)
    {
        Goal goal = _goals.Find(g => g.Name == goalName);
        if (goal != null)
        {
            int points = goal.RecordEvent();
            _score += points;
            Console.WriteLine($"Event recorded. Points earned: {points}. Total score: {_score}.");
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    public void DisplayGoals()
    {
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{goal.Name}: {goal.GetStatus()}");
        }
    }
}
