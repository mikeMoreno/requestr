using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requestr.Forms
{
    public class RequestPanel : Panel
    {
        public readonly ComboBox cmboMethod;
        public readonly TextBox txtUrl;

        public RequestPanel()
        {
            this.cmboMethod = new System.Windows.Forms.ComboBox();
            this.txtUrl = new System.Windows.Forms.TextBox();

            // 
            // cmboMethod
            // 
            this.cmboMethod.FormattingEnabled = true;
            this.cmboMethod.Items.AddRange(new object[] {
            "GET",
            "PUT",
            "POST",
            "PATCH",
            "DELETE",
            "HEAD"});
            this.cmboMethod.Location = new System.Drawing.Point(17, 33);
            this.cmboMethod.Name = "cmboMethod";
            this.cmboMethod.Size = new System.Drawing.Size(72, 23);
            this.cmboMethod.TabIndex = 1;

            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(95, 33);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(515, 23);
            this.txtUrl.TabIndex = 0;

            Controls.Add(this.cmboMethod);
            Controls.Add(this.txtUrl);
            Dock = System.Windows.Forms.DockStyle.Fill;
            Location = new System.Drawing.Point(3, 3);
            Name = "requestPanel1";
            Size = new System.Drawing.Size(743, 400);
            TabIndex = 2;
        }

    }
}
