using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculators
{
    public partial class MainForm : Form
    {
        private BMICalculator bmiCalculator = new BMICalculator();
        private FuelCalculator fuelCalculator = new FuelCalculator();

        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        //Initializing start up settings of GUI
        private void InitializeGUI()
        {
            this.Text = "Universal Calculator";
            radioButtonUS.Checked = true;
            labelBmiHight.Text = "Height (feet)";
            labelBmiWeight.Text = "Weight (lbs)";
            textBoxBmiHeight.Text = string.Empty;
            textBoxBmiWeight.Text = string.Empty;
            //groupFuel.Enabled = false;
        }

        //button BMI calculate event handler
        private void buttonBmiCalculate_Click(object sender, EventArgs e)
        {
            bool ok = ReadInputBMI();
            if (ok)
                DisplayResultsBMI();
        }

        //will veryfy if input for BMI calculation is correct 
        private bool ReadInputBMI()
        {
            bool okHeight = ReadInputBMIHeight();
            bool okWeight = ReadInputBMIWeight();
            ReadInputBMIName();
            return okHeight && okWeight;
        }

        //will veryfy if height in BMI calculations is correct
        private bool ReadInputBMIHeight()
        {
            bool ok = true;
            string strHight = textBoxBmiHeight.Text;
            strHight = strHight.Trim();

            double amountHight = 0.0;
            ok = double.TryParse(strHight, out amountHight);
            if (ok)
            {
                bmiCalculator.SetHeight(amountHight);
            }
            else
                ok = false;

            if (!ok)
                MessageBox.Show("Invalid height", "Error");
            return ok;
        }

        //will veryfy if weight in BMI calculations is correct
        private bool ReadInputBMIWeight()
        {
            bool ok = true;
            string strWeight = textBoxBmiWeight.Text;
            strWeight = strWeight.Trim();

            double amountWeight = 0.0;
            ok = double.TryParse(strWeight, out amountWeight);
            if (ok)
                bmiCalculator.SetWeight(amountWeight);
            else
                ok = false;

            if(!ok)
                MessageBox.Show("Invalid weight", "Error");
            return ok;
        }

        //will veryfy if name in BMI calculations is correct
        private void ReadInputBMIName()
        {
            string name = textBoxBmiName.Text;
            if (name == string.Empty)
                bmiCalculator.SetName("No name");
            else
                bmiCalculator.SetName(name);
        }


        //will display results for BMI calculations
        public void DisplayResultsBMI()
        {
            labelResultsBmi.Text = bmiCalculator.BMICalculations().ToString("0.00");
            labelResultsWeight.Text = bmiCalculator.BMIWeightCategory();
            labelResultsMessage.Text = "Normal BMI is between 18.5 and 24.9";
        }

        //radioButtonMetric event handler
        private void radioButtonMetric_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonMetric.Checked)
            {
                labelBmiHight.Text = "Height (cm)";
                labelBmiWeight.Text = "Weight (kg)";
                bmiCalculator.SetUnit(UnitTypes.Metric);
            }
        }

        //radioButtonUS event handler
        private void radioButtonUS_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUS.Checked)
            {
                labelBmiHight.Text = "Height (feet)";
                labelBmiWeight.Text = "Weight (lbs)";
                bmiCalculator.SetUnit(UnitTypes.American);
            }
        }

        //button Fuel calculate event handler
        private void buttonFuelCalculate_Click(object sender, EventArgs e)
        {
            bool ok = ReadInputFuel();
            if (ok)
                DisplayResultsFuel();
        }

        //will veryfy if input for Fuel calculation is correct 
        private bool ReadInputFuel()
        {
            bool okPreviousReading = ReadInputFuelPreviousReading();
            bool okCurrentReading = ReadInputFuelCurrentReading();
            bool okAmountOfFuel = ReadInputAmountOfFuel();
            bool okPriceOfPetrol = ReadInputPriceOfPetrol();
            
            return okCurrentReading && okPreviousReading && okAmountOfFuel && okPriceOfPetrol;
        }

        //will veryfy if Current Odometer Reading is correct
        private bool ReadInputFuelCurrentReading()
        {
            bool ok = true;
            string strCurrentOdometer = textBoxFuelCurrentOdometer.Text;
            strCurrentOdometer = strCurrentOdometer.Trim();

            double currentOdometer = 0.0;
            ok = double.TryParse(strCurrentOdometer, out currentOdometer);
            if (ok && currentOdometer > fuelCalculator.GetPreviousOdometer())
            {
                fuelCalculator.SetCurrentOdometer(currentOdometer);
            }
            else
                ok = false;

            if (!ok)
                MessageBox.Show("Invalid Current Odometer Value", "Error");
            return ok;
        }

        //will veryfy if Previous Odometer Reading is correct
        private bool ReadInputFuelPreviousReading()
        {
            bool ok = true;
            string strPreviousOdometer = textBoxFuelPreviousOdometer.Text;
            strPreviousOdometer = strPreviousOdometer.Trim();

            double previousOdometer = 0.0;
            ok = double.TryParse(strPreviousOdometer, out previousOdometer);
            if (ok)
            {
                fuelCalculator.SetPreviousOdometer(previousOdometer);
            }
            else
                ok = false;

            if (!ok)
                MessageBox.Show("Invalid Previous Odometer Value", "Error");
            return ok;
        }
    

        //will veryfy if Amount of Fuel Reading is correct
        private bool ReadInputAmountOfFuel()
        {
            bool ok = true;
            string strAmountOfFuel = textBoxFuelAmount.Text;
            strAmountOfFuel = strAmountOfFuel.Trim();

            double amountOfFuel = 0.0;
            ok = double.TryParse(strAmountOfFuel, out amountOfFuel);
            if (ok)
            {
                fuelCalculator.SetAmountOfFuel(amountOfFuel);
            }
            else
                ok = false;

            if (!ok)
                MessageBox.Show("Invalid Amount of Fuel", "Error");
            return ok;
        }


        //will veryfy if price of petrol is correct
        private bool ReadInputPriceOfPetrol()
        {
            bool ok = true;
            string strPriceOfFuel = textBoxFuelPrice.Text;
            strPriceOfFuel = strPriceOfFuel.Trim();

            double priceOfFuel = 0.0;
            ok = double.TryParse(strPriceOfFuel, out priceOfFuel);
            if (ok)
            {
                fuelCalculator.SetPriceOfFuel(priceOfFuel);
            }
            else
                ok = false;

            if (!ok)
                MessageBox.Show("Invalid Price of Fuel", "Error");
            return ok;

        }


        //will display results for Fuel calculations
        public void DisplayResultsFuel()
        {
            labelFuelResults1.Text = fuelCalculator.kmPerLit().ToString("0.00");
            labelFuelResults2.Text = fuelCalculator.litPerKm().ToString("0.00");
            labelFuelResults3.Text = fuelCalculator.litersPerMetricMile().ToString("0.00");
            labelFuelResults4.Text = fuelCalculator.literPerSwedMil().ToString("0.00");
            labelFuelResultsCost.Text = fuelCalculator.costPerKm().ToString("0.00");
        }
    }
}
