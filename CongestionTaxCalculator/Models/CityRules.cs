using System;
using System.Collections;
using System.Collections.Generic;
using CongestionTax.Database;
using Google.Cloud.Firestore;

namespace CongestionTax.Models
{
    /// <summary>
    /// Rules that govern how a city charges when a vehicle passes a toll gate
    /// </summary>
    [FirestoreData]
    public class CityRules
    {

        [FirestoreProperty]
        public List<TimeRule> Times { get; set; }

        /// <summary>
        /// Initialise city's rules using the 
        /// </summary>
        /// <param name="name">Name of the city. E.g "gothenburg" </param>
        /// <param name="times">List of time rules, E.g [{timeRange: "06:00-06:29", amount: 13}]</param>
        public CityRules(string name, List<TimeRule> times)
        {
            // initial value
            Name = name;
            Times = times;
            // sort times using comparer so that they are in logical order
            TimeRuleComparer trc = new TimeRuleComparer();
            Times.Sort(trc);
        }

        // name of the city
        public string Name { get; set; }

        override
        public string ToString()
        {
            string str = "";
            foreach(TimeRule t in Times)
            {
                str += $"{t.TimeRange} = {t.Amount}\n";
            }

            return str;
        }
    }
}

