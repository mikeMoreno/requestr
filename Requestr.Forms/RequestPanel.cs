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
        private RequestItem _requestItem;

        public RequestItem RequestItem {
            get
            {
                return _requestItem;
            }

            init
            {
                _requestItem = value;

                ComboMethod.SelectedItem = _requestItem!.Request.Method;
                TextUrl.Text = _requestItem.Request.Url.Raw;
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
