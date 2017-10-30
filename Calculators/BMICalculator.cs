using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculators
{   //class is taking care of Body Mass Index calculations 
    class BMICalculator
    {
        private string name = "No name";
        private double height = 0;
        private double weight = 0;
        private UnitTypes unit;


        public void SetName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetHeight(double height)
        {
            if (height > 0)
            {
                if (unit == UnitTypes.American)
                    this.height = height * 12;
                else
                    this.height = height / 100;
            }
        }

        public double GetHeight()
        {
            return height;
        }

        public void SetWeight(double weight)
        {
            if (weight > 0)
                this.weight = weight;
        }

        public double GetWeight()
        {
            return weight;
        }

        public void SetUnit(UnitTypes value)
        {
            this.unit = value;
        }


        public UnitTypes GetUnit()
        {
            return unit;
        }

        

        //BMI calculation 
        public double BMICalculations()
        {
            if(unit == UnitTypes.American)
                return 703.0 * weight / (height * height);
            return weight / (height * height);
        }

        //BMI weight category calculator
        public string BMIWeightCategory()
        {
            double bmi = BMICalculations();
            string output = string.Empty;
            if (bmi < 18.5)
                output = "Underweight";
            else if(bmi < 24.9)
                output = "Normal weight";
            else if (bmi < 29.9)
                output = "Overweight (Pre-obesity)";
            else if (bmi < 34.9)
                output = "Overweight (Obesity class I)";
            else if (bmi < 39.9)
                output = "Overweight (Obesity class II)";
            else 
                output = "Overweight (Obesity class III)";
            return output;
        }
    }

}
