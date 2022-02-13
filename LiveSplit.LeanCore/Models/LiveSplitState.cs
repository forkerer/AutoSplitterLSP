using LiveSplit.LeanCore.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveSplit.LeanCore.Models
{
    public class LiveSplitState
    {
        public AtomicDateTime AttemptStarted { get; set; }
        public AtomicDateTime AttemptEnded { get; set; }

        public TimeStamp AdjustedStartTime { get; set; }
        public TimeStamp StartTimeWithOffset { get; set; }
        public TimeStamp StartTime { get; set; }
        public TimeSpan TimePausedAt { get; set; }
        public TimeSpan? GameTimePauseTime { get; set; }
        public TimerPhase CurrentPhase { get; set; }
        public string CurrentComparison { get; set; }
        public TimingMethod CurrentTimingMethod { get; set; }
        public string CurrentHotkeyProfile { get; set; }

        internal TimeSpan? loadingTimes;
        public TimeSpan LoadingTimes
        {
            get
            {
                return loadingTimes ?? TimeSpan.Zero;
            }
            set
            {
                loadingTimes = value;
                if (IsGameTimePaused)
                {
                    GameTimePauseTime = CurrentTime.RealTime.Value - value;
                }
            }
        }
        public bool IsGameTimeInitialized
        {
            get
            {
                return loadingTimes.HasValue;
            }
            set
            {
                if (value)
                {
                    loadingTimes = LoadingTimes;
                }
                else
                    loadingTimes = null;
            }
        }
        private bool isGameTimePaused;
        public bool IsGameTimePaused
        {
            get { return isGameTimePaused; }
            set
            {
                if (!value && isGameTimePaused)
                    LoadingTimes = CurrentTime.RealTime.Value - (CurrentTime.GameTime ?? CurrentTime.RealTime.Value);
                else if (value && !isGameTimePaused)
                    GameTimePauseTime = (CurrentTime.GameTime ?? CurrentTime.RealTime);

                isGameTimePaused = value;
            }
        }

        public event EventHandler OnSplit;
        public event EventHandler OnUndoSplit;
        public event EventHandler OnSkipSplit;
        public event EventHandler OnStart;
        public event EventHandler OnReset;
        public event EventHandler OnPause;
        public event EventHandler OnUndoAllPauses;
        public event EventHandler OnResume;
        public event EventHandler OnScrollUp;
        public event EventHandler OnScrollDown;
        public event EventHandler OnSwitchComparisonPrevious;
        public event EventHandler OnSwitchComparisonNext;

        public event EventHandler RunManuallyModified;
        public event EventHandler ComparisonRenamed;

        public Time CurrentTime
        {
            get
            {
                var curTime = new Time();

                if (CurrentPhase == TimerPhase.NotRunning)
                    curTime.RealTime = TimeSpan.Zero;
                else if (CurrentPhase == TimerPhase.Running)
                    curTime.RealTime = TimeStamp.Now - AdjustedStartTime;
                else if (CurrentPhase == TimerPhase.Paused)
                    curTime.RealTime = TimePausedAt;
                else
                    curTime.RealTime = TimeSpan.Zero;// Run.Last().SplitTime.RealTime;

                if (CurrentPhase == TimerPhase.Ended)
                    curTime.GameTime = TimeSpan.Zero;//Run.Last().SplitTime.GameTime;
                else
                    curTime.GameTime = IsGameTimePaused
                        ? GameTimePauseTime
                        : curTime.RealTime - (IsGameTimeInitialized ? (TimeSpan?)LoadingTimes : null);

                return curTime;
            }
        }
    }
}
