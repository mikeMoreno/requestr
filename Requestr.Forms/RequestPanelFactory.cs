using Requestr.Lib;
using Requestr.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requestr.Forms
{
    public  class RequestPanelFactory
    {
        private readonly ICookieService cookieService;

        public RequestPanelFactory(ICookieService cookieService)
        {
            this.cookieService = cookieService;
        }

        public RequestPanel Build(Request request)
        {
            var requestPanel = new RequestPanel(request, cookieService)
            {
                Dock = DockStyle.Fill,
            };

            return requestPanel;
        }
    }
}
