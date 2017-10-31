using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculators
{
    class BMRCalculator
    {
        private char gender;
        private int age;
        private ActivityLevel activityLevel;
        private double height;
        private double weight;
        private UnitTypes unit;
        private string name;
        


        public void SetGender(char gender)
        {
            if (gender == 'F' || gender == 'M')
                this.gender = gender;
        }

        public char GetGender()
        {
            return gender;
        }

        public void SetAge(int age)
        {
            if(age >= 0)
                this.age = age;
        }

        public int GetAger()
        {
            return age;
        }

        public void SetActivityLevel(ActivityLevel activityLevel)
        {
            this.activityLevel = activityLevel;
        }

        public ActivityLevel GetActivityLevel()
        {
            return activityLevel;
        }

        public void SetHeight(double height)
        {
            if (height > 0)
                this.height = height;
        }

        public double GetHeight()
        {
            return height;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
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


        //calculation of BMR values
        public double BMRCalculation()
        {
            double bmr = 0.0;
            if (unit == UnitTypes.American)
                bmr = 10 * (weight / 2.2046) + 6.25 * (height * 30.48) - 5 * age;
            else bmr = 10 * weight + 6.25 * height - 5 * age;

            if (gender == 'F')
                return bmr - 161;
            else
                return bmr + 5;
        }

        //calculating calories to keep weight
        public double CaloriesToKeepWeigh()
        {
            double activeLevelFactor = 0;

            if (activityLevel == ActivityLevel.Zero)
                activeLevelFactor = 1.2;
            else if (activityLevel == ActivityLevel.Light)
                activeLevelFactor = 1.375;
            else if (activityLevel == ActivityLevel.Moderate)
                activeLevelFactor = 1.550;
            else if (activityLevel == ActivityLevel.Very)
                activeLevelFactor = 1.725;
            else if (activityLevel == ActivityLevel.VeryMuch)
                activeLevelFactor = 1.9;

            return BMRCalculation() * activeLevelFactor;
        }

    }
}