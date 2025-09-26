using System.Collections.Generic;

namespace YouTubeTracker
{
    public class Video
    {
        public string Title { get; }
        public string Author { get; }
        public int LengthSeconds { get; }

        private readonly List<Comment> _comments = new List<Comment>();
        public IEnumerable<Comment> Comments => _comments;

        public Video(string title, string author, int lengthSeconds)
        {
            Title = title ?? string.Empty;
            Author = author ?? string.Empty;
            LengthSeconds = lengthSeconds < 0 ? 0 : lengthSeconds;
        }

        public void AddComment(Comment comment)
        {
            if (comment != null) _comments.Add(comment);
        }

        public int GetCommentCount() => _comments.Count;
    }
}
