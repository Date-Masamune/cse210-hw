using System;
using System.IO;

namespace MindfulnessApp
{
    static class ActivityLogger
    {
        private const string FileName = "activity_log.txt";

        public static void Log(string activityName, int durationSeconds, DateTime startedAt, DateTime endedAt)
        {
            try
            {
                var line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}\t{activityName}\tDuration={durationSeconds}s\tStart={startedAt:HH:mm:ss}\tEnd={endedAt:HH:mm:ss}";
                File.AppendAllLines(FileName, new[] { line });
            }
            catch
            {
                
            }
        }
    }
}
