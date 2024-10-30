using System;

public abstract class Goal
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Points { get; protected set; }
    public bool IsCompleted { get; protected set; }

    protected Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsCompleted = false;
    }

    public abstract int RecordEvent();
    public abstract string GetStatus();
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points) {}

    public override int RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            return Points;
        }
        return 0;
    }

    public override string GetStatus() => IsCompleted ? "[X] Completed" : "[ ] Not Completed";
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) {}

    public override int RecordEvent() => Points;

    public override string GetStatus() => "[∞] Eternal Goal";
}

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) 
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        if (IsCompleted) return 0;

        _currentCount++;
        int earnedPoints = Points;
        
        if (_currentCount >= _targetCount)
        {
            IsCompleted = true;
            earnedPoints += _bonusPoints;
        }
        
        return earnedPoints;
    }

    public override string GetStatus()
    {
        return IsCompleted ? $"[X] Completed { _currentCount}/{_targetCount}" 
                           : $"[ ] Completed { _currentCount}/{_targetCount}";
    }
}
