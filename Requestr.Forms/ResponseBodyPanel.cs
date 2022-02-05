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
    public partial class ResponseBodyPanel : UserControl
    {
        public void SetText(string text)
        {
            txtBody.Text = text;
        }

        public ResponseBodyPanel()
        {
            InitializeComponent();
        }
    }
}
