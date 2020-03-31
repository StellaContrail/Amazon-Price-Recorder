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
    public partial class Setting_InputForm : Form
    {
        public Setting_InputForm()
        {
            InitializeComponent();
        }

        public Setting settings = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                MessageBox.Show("送信先メールアドレスが入力されていません");
                return;
            }
            if (textBox2.Text != "")
            {
                MessageBox.Show("IDが入力されていません");
                return;
            }
            if (textBox3.Text != "")
            {
                MessageBox.Show("パスワードが入力されていません");
                return;
            }
            settings = new Setting(textBox1.Text, textBox2.Text, textBox3.Text);

        }
    }
}
