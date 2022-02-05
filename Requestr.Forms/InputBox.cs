using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Requestr.Forms
{
    public partial class InputBox : Form
    {
        public string TextEntered { get; set; }

        public InputBox(string startText = null)
        {
            InitializeComponent();

            txtBox.Text = startText;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            TextEntered = null;

            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            TextEntered = txtBox.Text;

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
