using System;
using Google.Cloud.Firestore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CongestionTax.Models;

namespace CongestionTax.Database
{
    /// <summary>
    /// Procides access to Cloud Firestore database
    /// </summary>
    public class DBProvider
    {
        private readonly FirestoreDb _fireStoreDb = null!;

        public DBProvider(FirestoreDb fireStoreDb)
        {
            _fireStoreDb = fireStoreDb;
        }

        /// <summary>
        /// Get a city's charging rules for toll gates
        /// </summary>
        /// <param name="id">Name of the city used to idetify it in the database</param>
        /// <returns>The city's charging rules</returns>
        public async Task<CityRules> GetTimeRules(string id)
        {
            // get a document snapshot from firebase 
            var document = _fireStoreDb.Collection("time-rules").Document(id);
            var snapshot = await document.GetSnapshotAsync();

            List<TimeRule> timeRules = new List<TimeRule>();

            // if city is found, extract information
            if (snapshot.Exists) {

                // populate time rules using data from document snapshot
                List<Dictionary<string, string>> times = snapshot.GetValue<List<Dictionary<string, string>>>("times");
                foreach (Dictionary<string, string> timeRule in times)
                {
                    timeRules.Add(new TimeRule((String)timeRule["timeRange"], Double.Parse(timeRule["amount"])));
                }
            }


            return new CityRules(id, timeRules);
        }
    }
}

