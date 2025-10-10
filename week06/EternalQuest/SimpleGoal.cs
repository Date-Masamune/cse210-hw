namespace GoalTracker.Goals
{
    // One-and-done goal
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points)
            : base(name, description, points)
        {
            _isComplete = false; // good default; caller doesn't need to pass it
        }

        public override bool IsComplete => _isComplete;

        public override int RecordEvent()
        {
            if (_isComplete)
            {
                // Already completed; no extra points.
                return 0;
            }

            _isComplete = true;
            return Points;
        }

        // For loading from file
        public void MarkComplete() => _isComplete = true;

        public override string GetStringRepresentation()
        {
            // SimpleGoal|Name|Desc|Points|isComplete
            return $"SimpleGoal|{Name}|{Description}|{Points}|{_isComplete}";
        }
    }
}
