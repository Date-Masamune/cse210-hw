using System;
using System.Collections.Generic;

namespace YouTubeTracker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var v1 = new Video("Storm Time-lapse over Lincoln", "GreatPlainsWx", 315);
            var v2 = new Video("Intro to Supercells", "SkySchool", 780);
            var v3 = new Video("Chasing 101: Safety Basics", "RoadWiseWx", 540);
            var v4 = new Video("Nebraska Lightning Montage", "HeartlandStorms", 260);

            v1.AddComment(new Comment("Ava", "That shelf cloud is wild!"));
            v1.AddComment(new Comment("Marcus", "What lens are you using?"));
            v1.AddComment(new Comment("Jen", "Loved the speed of the time-lapse."));

            v2.AddComment(new Comment("Leo", "Clear explanation—thanks!"));
            v2.AddComment(new Comment("Priya", "Please cover LP vs HP next."));
            v2.AddComment(new Comment("Sam", "The diagrams helped a lot."));
            v2.AddComment(new Comment("Rae", "Where can I get the slides?"));

            v3.AddComment(new Comment("Chris", "Safety first—great reminders."));
            v3.AddComment(new Comment("Noah", "Do a gear checklist video!"));
            v3.AddComment(new Comment("Tess", "Wish I saw this earlier."));

            v4.AddComment(new Comment("Ivy", "Those crawlers are gorgeous."));
            v4.AddComment(new Comment("Owen", "What frame rate is this?"));
            v4.AddComment(new Comment("Mina", "Music fits perfectly."));
            v4.AddComment(new Comment("Drew", "Instant sub!"));

            var videos = new List<Video> { v1, v2, v3, v4 };

            foreach (var vid in videos)
            {
                Console.WriteLine($"Title:   {vid.Title}");
                Console.WriteLine($"Author:  {vid.Author}");
                Console.WriteLine($"Length:  {vid.LengthSeconds} seconds");
                Console.WriteLine($"Comments ({vid.GetCommentCount()}):");
                foreach (var c in vid.Comments)
                {
                    Console.WriteLine($"  - {c.AuthorName}: {c.Text}");
                }
                Console.WriteLine(new string('-', 48));
            }
        }
    }
}
