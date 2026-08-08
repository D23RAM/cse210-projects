using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int target,
        int bonus,
        int amountCompleted = 0)
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted >= _target)
        {
            Console.WriteLine("This checklist goal has already been completed!");
            return 0;
        }

        _amountCompleted++;

        int earnedPoints = GetPoints();

        // Give bonus when the target is reached.
        if (_amountCompleted == _target)
        {
            earnedPoints += _bonus;

            Console.WriteLine();
            Console.WriteLine("🎉 CHECKLIST COMPLETED!");
            Console.WriteLine($"Bonus: +{_bonus} points!");
        }

        return earnedPoints;
    }

    public override string GetDetailsString()
    {
        string checkbox =
            _amountCompleted >= _target ? "[X]" : "[ ]";

        return $"{checkbox} {GetName()} ({GetDescription()}) " +
               $"-- Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetName()}|{GetDescription()}|" +
               $"{GetPoints()}|{_target}|{_bonus}|{_amountCompleted}";
    }
}