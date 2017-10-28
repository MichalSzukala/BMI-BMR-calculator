using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculators
{
    class FuelCalculator
    {
        private double currentOdometer = 0;
        private double previousOdometer = 0;
        private double amountOfFuel = 0;
        private double priceOfFuel = 0;

        public void SetCurrentOdometer(double value)
        {
            if (value >= 0)
                currentOdometer = value;
        }

        public double GetCurrentOdometer()
        {
            return currentOdometer;
        }

        public void SetPreviousOdometer(double value)
        {
            if (value >= 0)
                previousOdometer = value;
        }

        public double GetPreviousOdometer()
        {
            return previousOdometer;
        }

        public void SetAmountOfFuel(double value)
        {
            if (value >= 0)
                amountOfFuel = value;
        }

        public double GetAmountOfFuel()
        {
            return amountOfFuel;
        }

        public void SetPriceOfFuel(double value)
        {
            if (value >= 0)
                priceOfFuel = value;
        }

        public double GetPriceOfFuel()
        {
            return priceOfFuel;
        }
    }
}
