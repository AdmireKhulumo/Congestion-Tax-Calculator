using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CongestionTax.Models
{
    /// <summary>
    /// Denotes a charging rule for a time period, e.g 06:00-06:29 costs 13
    /// </summary>
    public class TimeRule 
    {
        /// <summary>
        /// Initialise a time rule
        /// </summary>
        /// <param name="timeRange">When this charge applies, e.g 06:00-06:29</param>
        /// <param name="amount">Amount to charge a vehicle crossing at this time. E,g 13</param>
        public TimeRule(string timeRange, double amount)
        {
            TimeRange = timeRange;
            Amount = amount;

            // convert e.g 06:30-06:59 to start hour/minute, end hour/minute
            string[] strTimes = timeRange.Split('-');

            string[] timeStr = strTimes[0].Split(':');
            StartHour = Int32.Parse(timeStr[0]);
            StartMinute = Int32.Parse(timeStr[1]);

            timeStr = strTimes[1].Split(':');
            EndHour = Int32.Parse(timeStr[0]);
            EndMinute = Int32.Parse(timeStr[1]);
        }

        public double Amount { get; set; }

        public string TimeRange { get; set; }

        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int EndHour { get; set; }
        public int EndMinute { get; set; }

        override
        public string ToString()
        {
            return $"{TimeRange} = {Amount}";
        }
    }

    /// <summary>
    /// For comparing two time rules -- A < B if A's start time is before B's start time
    /// </summary>
    public class TimeRuleComparer : IComparer<TimeRule>
    {
        /// <summary>
        /// Compare teo Time Rules
        /// </summary>
        /// <param name="x">First time rule</param>
        /// <param name="y">Second timt rule</param>
        /// <returns></returns>
        public int Compare(TimeRule x, TimeRule y)
        {

            // convert e.g "06:29" to 629 for comparing start times 
            int startA = Int32.Parse($"{x.StartHour}{x.StartMinute}");
            int startB = Int32.Parse($"{y.StartHour}{y.StartMinute}");

            // compare and return result
            return startA.CompareTo(startB);

        }
    }

}
