using System;


// I added a gamification system to my program. 
// In addition to the required scoring system, 
// I added levels based on the user's XP and achievement badges for reaching different milestones.
// The level system gives users a title as they progress, such as Beginner, Seeker, Disciple, Faithful, and Eternal Warrior. 
// I added this because the purpose of the project is to encourage people to keep working toward long-term goals by giving them smaller rewards and accomplishments along the way.
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        bool running = true;

        while (running)
        {
            Console.Clear();

            DisplayHeader(manager);

            Console.WriteLine();
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");

            Console.WriteLine();
            Console.Write("Select a choice: ");

            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    Pause();
                    break;

                case "2":
                    manager.DisplayGoals();
                    Pause();
                    break;

                case "3":
                    RecordGoal(manager);
                    Pause();
                    break;

                case "4":
                    manager.SaveGoals("goals.txt");
                    Pause();
                    break;

                case "5":
                    manager.LoadGoals("goals.txt");
                    Pause();
                    break;

                case "6":
                    running = false;

                    Console.WriteLine(
                        "Goodbye! Keep working on your Eternal Quest! 🙏");

                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    Pause();
                    break;
            }
        }
    }

   
    // HEADER
    

    static void DisplayHeader(GoalManager manager)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("          🌟 ETERNAL QUEST 🌟");
        Console.WriteLine("========================================");

        Console.WriteLine(
            $"Score: {manager.GetScore()} XP");

        Console.WriteLine(
            $"Level: {manager.GetLevel()} - {manager.GetLevelName()}");

        Console.WriteLine("========================================");
    }


    // CREATE GOAL


    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("===== CREATE NEW GOAL =====");
        Console.WriteLine();

        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.WriteLine();
        Console.Write("Which type of goal? ");

        string type = Console.ReadLine();

        if (type != "1" &&
            type != "2" &&
            type != "3")
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("Goal name: ");
        string name = Console.ReadLine();

        Console.Write("Goal description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        // SIMPLE GOAL
        if (type == "1")
        {
            SimpleGoal goal = new SimpleGoal(
                name,
                description,
                points);

            manager.AddGoal(goal);

            Console.WriteLine();
            Console.WriteLine("Simple goal created!");
        }

        // ETERNAL GOAL
        else if (type == "2")
        {
            EternalGoal goal = new EternalGoal(
                name,
                description,
                points);

            manager.AddGoal(goal);

            Console.WriteLine();
            Console.WriteLine("Eternal goal created!");
        }

        // CHECKLIST GOAL
        else if (type == "3")
        {
            Console.Write(
                "How many times must it be completed? ");

            int target = int.Parse(Console.ReadLine());

            Console.Write(
                "Bonus points for completing it: ");

            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal goal = new ChecklistGoal(
                name,
                description,
                points,
                target,
                bonus);

            manager.AddGoal(goal);

            Console.WriteLine();
            Console.WriteLine("Checklist goal created!");
        }
    }

   
    // RECORD GOAL
    

    static void RecordGoal(GoalManager manager)
    {
        manager.DisplayGoals();

        Console.WriteLine();

        Console.Write(
            "Which goal did you accomplish? ");

        string input = Console.ReadLine();

        if (int.TryParse(input, out int goalNumber))
        {
            manager.RecordEvent(goalNumber - 1);
        }
        else
        {
            Console.WriteLine(
                "Please enter a valid number.");
        }
    }

   
    // PAUSE
    

    static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine(
            "Press ENTER to continue...");

        Console.ReadLine();
    }
}