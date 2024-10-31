using System;

public class Running : Activity
{
    private double distance; 

    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;
    public override double GetSpeed() => (distance / Duration) * 60;
    public override double GetPace() => Duration / distance;
}
