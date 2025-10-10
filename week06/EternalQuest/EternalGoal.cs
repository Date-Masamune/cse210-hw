namespace GoalTracker.Goals
{
    // Never completes; awards points every time
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points) { }

        public override int RecordEvent()
        {
            // Always earns points; never completes
            return Points;
        }

        public override string GetStringRepresentation()
        {
            // EternalGoal|Name|Desc|Points
            return $"EternalGoal|{Name}|{Description}|{Points}";
        }
    }
}
