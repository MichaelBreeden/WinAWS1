using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAWS1
{
    public partial class FormInput : Form
    {
        public FormInput()
        {
            InitializeComponent();
            Input_label.Text = Form1.strInputLabelText;
        }

        private void InputClose_button_Click(object sender, EventArgs e)
        {
            Form1.strInputText = String.Empty;
            this.Close();
        }

        private void InputSave_button_Click(object sender, EventArgs e)
        {
            Form1.strInputText = Input_textBox.Text;
            this.Close();
        }
    }
}
