using System;
using PropertyChanged;

namespace ThirtySixQuestions.Models
{
    [AddINotifyPropertyChangedInterface]
    public class TimerModel
    {
        public DateTime Date { get; set; }
        public TimeSpan Timespan { get; set; }
        public string Minutes => Timespan.Minutes.ToString("00");
        public string Seconds => Timespan.Seconds.ToString("00");
        public string BgColor { get; set; }
    }
}
