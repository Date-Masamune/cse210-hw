using System;

namespace YouTubeTracker
{
    public class Comment
    {
        public string AuthorName { get; }
        public string Text { get; }

        public Comment(string authorName, string text)
        {
            AuthorName = authorName ?? string.Empty;
            Text = text ?? string.Empty;
        }
    }
}
