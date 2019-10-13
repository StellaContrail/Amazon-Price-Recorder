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
    public partial class ASIN_InputForm : Form
    {
        public ASIN_InputForm()
        {
            InitializeComponent();
        }

        public string value { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("入力してください");
            }
            else
            {
                value = textBox1.Text;
            }
        }
    }
}
