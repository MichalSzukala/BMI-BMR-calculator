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
    }
}
