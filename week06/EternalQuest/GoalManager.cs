using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using GoalTracker.Goals;

namespace GoalTracker
{
    public class GoalManager
    {
        private readonly List<Goal> _goals = new();
        private int _score = 0;

        public void RunMenu()
        {
            while (true)
            {
                Console.WriteLine();
                int level = LevelFromScore(_score);
                int next = NextLevelAt(level);
                int toNext = Math.Max(0, next - _score);
                Console.WriteLine($"You have {_score} points.  Level {level}  ( {toNext} to next )");
                Console.WriteLine();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  6. Quit");
                Console.Write("Select a choice from the menu: ");

                var choice = Console.ReadLine()?.Trim();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": CreateGoal(); break;
                    case "2": ListGoals(); break;
                    case "3": SaveGoals(); break;
                    case "4": LoadGoals(); break;
                    case "5": RecordEvent(); break;
                    case "6": return;
                    default:
                        Console.WriteLine("Please enter 1–6.");
                        break;
                }
            }
        }

        private void CreateGoal()
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            var type = Console.ReadLine();

            Console.Write("What is the name of your goal? ");
            var name = Console.ReadLine() ?? "";
            Console.Write("What is a short description of it? ");
            var desc = Console.ReadLine() ?? "";
            Console.Write("What is the amount of points associated with this goal? ");
            var points = ParseInt();

            Goal goal;

            switch (type)
            {
                case "1":
                    goal = new SimpleGoal(name, desc, points);
                    break;

                case "2":
                    goal = new EternalGoal(name, desc, points);
                    break;

                case "3":
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    var target = ParseInt();
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    var bonus = ParseInt();
                    goal = new ChecklistGoal(name, desc, points, target, bonus);
                    break;

                default:
                    Console.WriteLine("Unknown type. Cancelled.");
                    return;
            }

            _goals.Add(goal);
            Console.WriteLine("Goal created!");
        }

        private void ListGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet.");
                return;
            }

            Console.WriteLine("Your goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                var g = _goals[i];
                Console.WriteLine($"{i + 1}. {g.GetDetailsString()}");
            }
        }

        private void SaveGoals()
        {
            Console.Write("Enter filename to save (e.g., goals.txt): ");
            var file = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(file)) { Console.WriteLine("Cancelled."); return; }

            using var sw = new StreamWriter(file);
            sw.WriteLine(_score.ToString(CultureInfo.InvariantCulture));
            foreach (var g in _goals)
            {
                sw.WriteLine(g.GetStringRepresentation());
            }
            Console.WriteLine("Saved!");
        }

        private void LoadGoals()
        {
            Console.Write("Enter filename to load: ");
            var file = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(file) || !File.Exists(file))
            {
                Console.WriteLine("File not found.");
                return;
            }

            var lines = File.ReadAllLines(file);
            _goals.Clear();

            if (lines.Length == 0) { _score = 0; return; }

            _score = int.TryParse(lines[0], out var s) ? s : 0;

            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split('|', StringSplitOptions.None);
                if (parts.Length < 4) continue;

                var type = parts[0];
                var name = parts[1];
                var desc = parts[2];
                var points = int.Parse(parts[3], CultureInfo.InvariantCulture);

                switch (type)
                {
                    case "SimpleGoal":
                        // SimpleGoal|Name|Desc|Points|isComplete
                        bool isComplete = parts.Length >= 5 && bool.TryParse(parts[4], out var b) && b;
                        var sg = new SimpleGoal(name, desc, points);
                        if (isComplete) sg.MarkComplete();
                        _goals.Add(sg);
                        break;

                    case "EternalGoal":
                        // EternalGoal|Name|Desc|Points
                        _goals.Add(new EternalGoal(name, desc, points));
                        break;

                    case "ChecklistGoal":
                        // ChecklistGoal|Name|Desc|Points|current|target|bonus
                        if (parts.Length >= 7)
                        {
                            int current = int.Parse(parts[4], CultureInfo.InvariantCulture);
                            int target = int.Parse(parts[5], CultureInfo.InvariantCulture);
                            int bonus = int.Parse(parts[6], CultureInfo.InvariantCulture);
                            var cg = new ChecklistGoal(name, desc, points, target, bonus, current);
                            _goals.Add(cg);
                        }
                        break;
                }
            }

            Console.WriteLine("Loaded!");
        }

        private void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals to record yet.");
                return;
            }

            Console.WriteLine("Which goal did you accomplish?");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].Name}");
            }
            Console.Write("Enter number: ");
            int idx = ParseInt() - 1;
            if (idx < 0 || idx >= _goals.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            var before = LevelFromScore(_score);
            var goal = _goals[idx];
            int earned = goal.RecordEvent();
            _score += earned;
            var after = LevelFromScore(_score);

            Console.WriteLine($"Event recorded! You earned {earned} points.");
            if (after > before)
            {
                Console.WriteLine($"🎉 Level up! You reached Level {after}!");
            }
            Console.WriteLine($"New total: {_score} points.");
        }

        private static int ParseInt()
        {
            while (true)
            {
                var raw = Console.ReadLine();
                if (int.TryParse(raw, NumberStyles.Integer, CultureInfo.InvariantCulture, out int val))
                    return val;
                Console.Write("Enter a whole number: ");
            }
        }

        // --- Leveling helpers (500 pts per level) ---
        private int LevelFromScore(int score) => Math.Max(1, score / 500 + 1);
        private int NextLevelAt(int level) => level * 500;
    }
}
