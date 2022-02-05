using Requestr.Lib.Models;
using Requestr.PostmanImporter;
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
    public partial class RequestPanel : UserControl
    {
        private Request _request;

        public Request RequestItem {
            get
            {
                return _request;
            }

            init
            {
                _request = value;

                ComboMethod.SelectedItem = _request.Method;
                TextUrl.Text = _request.Url;
            }
        }

        public ComboBox ComboMethod
        {
            get => comboMethod;
        }

        public TextBox TextUrl
        {
            get => textUrl;
        }

        public RequestPanel()
        {
            InitializeComponent();


        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }
    }
}
