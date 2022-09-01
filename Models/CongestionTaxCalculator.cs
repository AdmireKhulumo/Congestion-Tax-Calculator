using System;
namespace CongestionTax.Models
{
    public class CongestionTaxCalculator
    {

        /// <summary>
        /// Calculate the total toll fee for one day
        /// </summary>
        /// <param name="vehicle">The vehivle object</param>
        /// <param name="dates">Array of dates with times when toll gate was passed.</param>
        /// <param name="cr">City's charging rules to apply for each toll gate passed</param>
        public double GetTax(Vehicle vehicle, DateTime[] dates, CityRules cr)
        {
            // sort in ascending order first
            Array.Sort(dates);

            // get first date
            DateTime intervalStart = dates[0];

            // fee counter
            double totalFee = 0;

            // loop through times from first to last
            foreach (DateTime date in dates)
            {
                // get fee for the current time
                double nextFee = GetTollFee(date, vehicle, cr);

                // temporary for fee from begining of interval
                double tempFee = GetTollFee(intervalStart, vehicle, cr);

                // convert to minutes
                double minutes = (date - intervalStart).TotalMinutes;

                // 60 mins or less in this interval
                if (minutes <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    // more than 60 mins, add this fee to the total
                    totalFee += nextFee;
                    // reset interval before moving to the next time
                    intervalStart = date;
                }
            }

            // when total is above 60, return 60
            if (totalFee > 60) totalFee = 60;

            return totalFee;
        }

        /// <summary>
        /// Get the toll fee for a single date with time
        /// </summary>
        /// <param name="date">Date and time when toll gate was crossed</param>
        /// /// <param name="vehicle">The vehicle object</param>
        /// <param name="cr">City's charging rules to apply for each toll gate crossed</param>
        /// <returns>The amount to be charged for that one crossing depending on the city's rules</returns>
        public double GetTollFee(DateTime date, Vehicle vehicle, CityRules cr)
        {
            if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

            int hour = date.Hour;
            int minute = date.Minute;

            // calculate according to times in the rules -- default to 0
            double amnt = 0;


            // loop though soryed list of times and amounts (TimeRules)
            foreach (TimeRule tr in cr.Times) {
                // check if time is in this range
                if( hour>= tr.StartHour && hour <= tr.EndHour && minute >= tr.StartMinute && minute <= tr.EndMinute)
                {
                    amnt = tr.Amount;
                }
            }

            // no match found,
            return amnt;
        }

        /// <summary>
        /// Check if the vehicle is eligible for toll free crossing
        /// </summary>
        /// <param name="vehicle">Vehicle object</param>
        /// <returns>true is vehivle can cross for free</returns>
        private bool IsTollFreeVehicle(Vehicle vehicle)
        {
            // check if vehicle object was supplied
            if (vehicle == null) return false;

            // type of vehicle -- cra, motorbike, etc
            String vehicleType = vehicle.GetVehicleType();

            // check if it matches names in the enum
            return vehicleType.Equals(TollFreeVehicles.Motorcycle.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Tractor.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Emergency.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Diplomat.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Foreign.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Military.ToString());
        }

        /// <summary>
        /// Check if a date is excluded from payments
        /// </summary>
        /// <param name="date">Date of crossing</param>
        /// <returns>true if this is a free crossing day</returns>
        private Boolean IsTollFreeDate(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

            if (year == 2013)
            {
                if (month == 1 && day == 1 ||
                    month == 3 && (day == 28 || day == 29) ||
                    month == 4 && (day == 1 || day == 30) ||
                    month == 5 && (day == 1 || day == 8 || day == 9) ||
                    month == 6 && (day == 5 || day == 6 || day == 21) ||
                    month == 7 ||
                    month == 11 && day == 1 ||
                    month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Enum of toll free vehicles
        /// </summary>
        private enum TollFreeVehicles
        {
            Motorcycle = 0,
            Tractor = 1,
            Emergency = 2,
            Diplomat = 3,
            Foreign = 4,
            Military = 5
        }
    }
}