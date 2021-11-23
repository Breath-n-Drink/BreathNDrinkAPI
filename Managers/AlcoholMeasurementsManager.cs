using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreathNDrinkClassLibrary;

namespace BreathNDrinkAPI.Managers
{
    public static class AlcoholMeasurementsManager
    {
        private static List<AlcoholMeasurement> _alcoholMeasurements = new();

        public static void AddMeasurement(AlcoholMeasurement measurement)
        {
            _alcoholMeasurements.Add(measurement);
        }

        public static List<AlcoholMeasurement> GetMeasurements(string userId = null)
        {
            List<AlcoholMeasurement> measurements = new List<AlcoholMeasurement>(_alcoholMeasurements);

            if (userId != null)
                measurements = measurements.FindAll(m => m.UserId.Equals(userId));

            return measurements;
        }
    }
}
