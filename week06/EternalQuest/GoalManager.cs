using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public int GetScore()
    {
        return _score;
    }


    // LEVEL SYSTEM
   

    public int GetLevel()
    {
        return (_score / 500) + 1;
    }

    public string GetLevelName()
    {
        int level = GetLevel();

        if (level == 1)
        {
            return "Beginner";
        }
        else if (level == 2)
        {
            return "Seeker";
        }
        else if (level == 3)
        {
            return "Disciple";
        }
        else if (level == 4)
        {
            return "Faithful";
        }
        else if (level == 5)
        {
            return "Eternal Warrior";
        }
        else
        {
            return "Legend";
        }
    }

 
    // DISPLAY GOALS
    

    public void DisplayGoals()
    {
        Console.WriteLine();
        Console.WriteLine("===== YOUR GOALS =====");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

  
    // RECORD EVENT


    public void RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int oldLevel = GetLevel();


        int pointsEarned = _goals[index].RecordEvent();

        _score += pointsEarned;

        if (pointsEarned > 0)
        {
            Console.WriteLine();
            Console.WriteLine($"🎉 You earned {pointsEarned} points!");
            Console.WriteLine($"Total score: {_score}");

            int newLevel = GetLevel();

            if (newLevel > oldLevel)
            {
                Console.WriteLine();
                Console.WriteLine("🌟 LEVEL UP! 🌟");
                Console.WriteLine(
                    $"You are now Level {newLevel} - {GetLevelName()}!");
            }

            CheckAchievements();
        }
    }


    // ACHIEVEMENTS
    

    private void CheckAchievements()
    {
        if (_score >= 100)
        {
            Console.WriteLine("🏆 Achievement: First 100 XP!");
        }

        if (_score >= 500)
        {
            Console.WriteLine("🏆 Achievement: Level 2!");
        }

        if (_score >= 1000)
        {
            Console.WriteLine("🏆 Achievement: 1,000 XP!");
        }

        if (_score >= 5000)
        {
            Console.WriteLine("🏆 Achievement: Eternal Warrior!");
        }
    }


    // SAVE


    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // Save the score first.
            outputFile.WriteLine(_score);

            // Save every goal.
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(
                    goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    
    // LOAD


    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("Save file is empty.");
            return;
        }

        _goals.Clear();

        // First line contains the score.
        _score = int.Parse(lines[0]);

        // Load each goal.
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            string goalType = parts[0];

            if (goalType == "SimpleGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                bool completed = bool.Parse(parts[4]);

                SimpleGoal goal = new SimpleGoal(
                    name,
                    description,
                    points,
                    completed);

                _goals.Add(goal);
            }

            else if (goalType == "EternalGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                EternalGoal goal = new EternalGoal(
                    name,
                    description,
                    points);

                _goals.Add(goal);
            }

            else if (goalType == "ChecklistGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                int target = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int amountCompleted = int.Parse(parts[6]);

                ChecklistGoal goal = new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus,
                    amountCompleted);

                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }
}