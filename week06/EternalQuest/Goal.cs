namespace GoalTracker.Goals
{
    // Base (abstract) class for all goal types
    public abstract class Goal
    {
        public string Name { get; }
        public string Description { get; }
        public int Points { get; }

        protected Goal(string name, string description, int points)
        {
            Name = name;
            Description = description;
            Points = points;
        }

        // Default: goals are not "complete" unless a derived class says so.
        public virtual bool IsComplete => false;

        // Default details string; ChecklistGoal overrides to add its counter.
        public virtual string GetDetailsString()
        {
            string checkbox = IsComplete ? "[X]" : "[ ]";
            return $"{checkbox} {Name} ({Description})";
        }

        // Abstract "action" method that each derived class must implement.
        // Returns the points earned for recording the event.
        public abstract int RecordEvent();

        // Used for saving/loading
        public abstract string GetStringRepresentation();
    }
}
