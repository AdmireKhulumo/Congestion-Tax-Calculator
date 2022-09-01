using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CongestionTax.Models;
using CongestionTax.Database;
using Google.Api;

namespace CongestionTax.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CongestionTaxController : Controller
    {

        private readonly DBProvider _dbProvider;

        public CongestionTaxController(DBProvider dbProvider)
        {

            // inject db provider
            _dbProvider = dbProvider;
        }

        /// <summary>
        /// Get the congestion tax for a single day
        /// </summary>
        /// <param name="city">Name of the city whose charging rules to apply. E.g "gothenburg"</param>
        /// <param name="type">Type of vehicle. E.g "bus"</param>
        /// <param name="datesStr">String of dates and times when the vehivle passed a toll gate  (separated by a comma). E.g "2013-02-08 06:27:00, 2013-02-08 14:35:00 , 2013-02-08 15:29:00" </param>
        /// <returns>The total congestion tax for that day. E.g {"congestion-tax" : 48}</returns>
        [HttpPost]
        public async Task<Dictionary<string, double>> GetAsync(string city, string type, string datesStr)
        {
            string test = "2013-02-08 06:20:27,2013-02-08 06:27:00, 2013-02-08 14:35:00 , 2013-02-08 15:29:00 , 2013-02-08 15:47:00 , 2013-02-08 16:01:00 , 2013-02-08 16:48:00,2013-02-08 17:49:00 ,  2013-02-08 17:55:00,2013-02-08 18:01:00, 2013-02-08 18:29:00, 2013-02-08 18:35:00, 2013-02-08 18:40:00";

            // create a vehicle object 
            Vehicle veh = createVehObj(type);

            // get charging rules from the database
            CityRules cr = await _dbProvider.GetTimeRules(city);

            // convert to array of strings
            string[] datesArr = datesStr.Split(',');

            // convert to array of date strings to DateTime objects
            int n = datesArr.Length;
            DateTime[] dates = new DateTime[n];
            for (int i = 0; i < n; i++){
                dates[i] = DateTime.Parse(datesArr[i].Trim());
            }

            // pass to calculator
            double tax = new Models.CongestionTaxCalculator().GetTax(veh, dates, cr);

            // return tax
            Dictionary<string, double> res = new Dictionary<string, double>();
            res.Add("congestion-tax", tax);
            return res;
        }

        /// <summary>
        /// Initialise a new vehicle object using its type
        /// </summary>
        /// <param name="type">Type of vehicle. E.g "bus"</param>
        /// <returns>The vehicle object created</returns>
        private Vehicle createVehObj(string type)
        {
            switch (type.ToLower())
            {
                case "motorcycle":
                    return new Motorcycle();
                case "tractor":
                    return new Tractor();
                case "bus":
                    return new Bus();
                case "emergency":
                    return new Emergency();
                case "diplomat":
                    return new Diplomat();
                case "foreign":
                    return new Foreign();
                case "military":
                    return new Military();
                default:
                    return new Car();

            }
        }

    }
}

