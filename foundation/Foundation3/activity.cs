using System;

public class Activity
{
    private DateTime date;
    private int duration; 

    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    public int Duration => duration;
    public DateTime Date => date;

    public virtual double GetDistance() => 0;
    public virtual double GetSpeed() => 0;
    public virtual double GetPace() => 0;

    public virtual string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} Activity ({duration} min): Distance {GetDistance():0.0} km, Speed {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}
