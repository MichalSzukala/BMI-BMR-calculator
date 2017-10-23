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
        }

        
    }
}
