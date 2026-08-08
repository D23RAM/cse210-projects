using System;

public class EternalGoal : Goal
{
    public EternalGoal(
        string name,
        string description,
        int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Eternal goals can be completed repeatedly.
        return GetPoints();
    }

    public override string GetDetailsString()
    {
        return $"[ ] {GetName()} ({GetDescription()})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{GetName()}|{GetDescription()}|{GetPoints()}";
    }
}