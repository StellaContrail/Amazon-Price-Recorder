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
        public Setting_InputForm(Setting presentSetting)
        {
            InitializeComponent();
            MailTextBox.Text = presentSetting.Email;
            IdTextBox.Text = presentSetting.Id;
            PassTextBox.Text = presentSetting.Pass;
        }

        public Setting newSetting = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (MailTextBox.Text == "")
            {
                MessageBox.Show("送信先メールアドレスが入力されていません");
                return;
            }
            if (IdTextBox.Text == "")
            {
                MessageBox.Show("IDが入力されていません");
                return;
            }
            if (PassTextBox.Text == "")
            {
                MessageBox.Show("パスワードが入力されていません");
                return;
            }
            newSetting = new Setting(MailTextBox.Text, IdTextBox.Text, PassTextBox.Text);
        }
    }
}
