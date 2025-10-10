namespace GoalTracker.Goals
{
    // Requires N completions; awards bonus when done
    public class ChecklistGoal : Goal
    {
        private int _current;
        private readonly int _target;
        private readonly int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus, int current = 0)
            : base(name, description, points)
        {
            _target = target;
            _bonus = bonus;
            _current = current;
        }

        public override bool IsComplete => _current >= _target;

        public override string GetDetailsString()
        {
            string checkbox = IsComplete ? "[X]" : "[ ]";
            return $"{checkbox} {Name} ({Description}) -- Currently: {_current}/{_target}";
        }

        public override int RecordEvent()
        {
            _current++;

            // Base points always awarded
            int earned = Points;

            // If this event completes the checklist, add bonus once
            if (_current == _target)
            {
                earned += _bonus;
            }

            return earned;
        }

        public override string GetStringRepresentation()
        {
            // ChecklistGoal|Name|Desc|Points|current|target|bonus
            return $"ChecklistGoal|{Name}|{Description}|{Points}|{_current}|{_target}|{_bonus}";
        }
    }
}
