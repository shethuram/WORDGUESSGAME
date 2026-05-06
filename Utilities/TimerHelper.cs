using System.Diagnostics;

namespace WordGuessGame.Utilities
{
    public class TimerHelper
    {
        private readonly Stopwatch _stopwatch = new();

        public void Start()
        {
            _stopwatch.Start();
        }

        public void Stop()
        {
            _stopwatch.Stop();
        }

        public long GetElapsedSeconds()
        {
            return _stopwatch.Elapsed.Seconds;
        }
    }
}