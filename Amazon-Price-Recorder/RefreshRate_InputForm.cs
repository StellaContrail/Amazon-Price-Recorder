using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amazon_Price_Recorder
{
    public partial class RefreshRate_InputForm : Form
    {
        public RefreshRate_InputForm(decimal interval)
        {
            InitializeComponent();
            numericUpDown1.Value = interval;
        }

        public decimal value { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            value = numericUpDown1.Value;
        }
    }
}
