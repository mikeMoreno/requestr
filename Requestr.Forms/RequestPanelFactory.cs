using Requestr.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requestr.Forms
{
    public static class RequestPanelFactory
    {
        public static RequestPanel Build(Request request)
        {
            var requestPanel = new RequestPanel(Globals.HttpClient, request)
            {
                Dock = DockStyle.Fill,
            };

            return requestPanel;
        }
    }
}
