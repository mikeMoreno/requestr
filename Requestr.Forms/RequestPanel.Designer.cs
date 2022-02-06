namespace Requestr.Forms
{
    partial class RequestPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboMethod = new System.Windows.Forms.ComboBox();
            this.textUrl = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tabsResponses = new System.Windows.Forms.TabControl();
            this.tabResponseBody = new System.Windows.Forms.TabPage();
            this.responseBodyPanel = new Requestr.Forms.ResponseBodyPanel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabHeaders = new System.Windows.Forms.TabPage();
            this.tabRequestBody = new System.Windows.Forms.TabPage();
            this.txtHeaders = new System.Windows.Forms.RichTextBox();
            this.tabsResponses.SuspendLayout();
            this.tabResponseBody.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabHeaders.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboMethod
            // 
            this.comboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMethod.FormattingEnabled = true;
            this.comboMethod.Items.AddRange(new object[] {
            "GET",
            "PUT",
            "POST",
            "PATCH",
            "DELETE",
            "HEAD"});
            this.comboMethod.Location = new System.Drawing.Point(17, 33);
            this.comboMethod.Name = "comboMethod";
            this.comboMethod.Size = new System.Drawing.Size(72, 23);
            this.comboMethod.TabIndex = 1;
            // 
            // textUrl
            // 
            this.textUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textUrl.Location = new System.Drawing.Point(95, 33);
            this.textUrl.Name = "textUrl";
            this.textUrl.Size = new System.Drawing.Size(515, 23);
            this.textUrl.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(626, 33);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // tabsResponses
            // 
            this.tabsResponses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsResponses.Controls.Add(this.tabResponseBody);
            this.tabsResponses.Location = new System.Drawing.Point(3, 253);
            this.tabsResponses.Name = "tabsResponses";
            this.tabsResponses.SelectedIndex = 0;
            this.tabsResponses.Size = new System.Drawing.Size(702, 334);
            this.tabsResponses.TabIndex = 3;
            // 
            // tabResponseBody
            // 
            this.tabResponseBody.Controls.Add(this.responseBodyPanel);
            this.tabResponseBody.Location = new System.Drawing.Point(4, 24);
            this.tabResponseBody.Name = "tabResponseBody";
            this.tabResponseBody.Padding = new System.Windows.Forms.Padding(3);
            this.tabResponseBody.Size = new System.Drawing.Size(694, 306);
            this.tabResponseBody.TabIndex = 0;
            this.tabResponseBody.Text = "Response Body";
            this.tabResponseBody.UseVisualStyleBackColor = true;
            // 
            // responseBodyPanel
            // 
            this.responseBodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.responseBodyPanel.Location = new System.Drawing.Point(3, 3);
            this.responseBodyPanel.Name = "responseBodyPanel";
            this.responseBodyPanel.Size = new System.Drawing.Size(688, 300);
            this.responseBodyPanel.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(7, 235);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 15);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status:";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(111, 235);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(30, 15);
            this.lblSize.TabIndex = 5;
            this.lblSize.Text = "Size:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(196, 235);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(36, 15);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "Time:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabHeaders);
            this.tabControl1.Controls.Add(this.tabRequestBody);
            this.tabControl1.Location = new System.Drawing.Point(7, 72);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(694, 160);
            this.tabControl1.TabIndex = 7;
            // 
            // tabHeaders
            // 
            this.tabHeaders.Controls.Add(this.txtHeaders);
            this.tabHeaders.Location = new System.Drawing.Point(4, 24);
            this.tabHeaders.Name = "tabHeaders";
            this.tabHeaders.Padding = new System.Windows.Forms.Padding(3);
            this.tabHeaders.Size = new System.Drawing.Size(686, 132);
            this.tabHeaders.TabIndex = 0;
            this.tabHeaders.Text = "Headers";
            this.tabHeaders.UseVisualStyleBackColor = true;
            // 
            // tabRequestBody
            // 
            this.tabRequestBody.Location = new System.Drawing.Point(4, 24);
            this.tabRequestBody.Name = "tabRequestBody";
            this.tabRequestBody.Padding = new System.Windows.Forms.Padding(3);
            this.tabRequestBody.Size = new System.Drawing.Size(686, 132);
            this.tabRequestBody.TabIndex = 1;
            this.tabRequestBody.Text = "Request Body";
            this.tabRequestBody.UseVisualStyleBackColor = true;
            // 
            // txtHeaders
            // 
            this.txtHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHeaders.Location = new System.Drawing.Point(3, 3);
            this.txtHeaders.Name = "txtHeaders";
            this.txtHeaders.Size = new System.Drawing.Size(680, 126);
            this.txtHeaders.TabIndex = 0;
            this.txtHeaders.Text = "";
            // 
            // RequestPanel
            // 
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tabsResponses);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.comboMethod);
            this.Controls.Add(this.textUrl);
            this.Location = new System.Drawing.Point(3, 3);
            this.Name = "RequestPanel";
            this.Size = new System.Drawing.Size(708, 590);
            this.tabsResponses.ResumeLayout(false);
            this.tabResponseBody.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabHeaders.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ComboBox comboMethod;
        private TextBox textUrl;

        #endregion

        private Button btnSend;
        private TabControl tabsResponses;
        private TabPage tabResponseBody;
        private ResponseBodyPanel responseBodyPanel;
        private Label lblStatus;
        private Label lblSize;
        private Label lblTime;
        private TabControl tabControl1;
        private TabPage tabHeaders;
        private TabPage tabRequestBody;
        private RichTextBox txtHeaders;
    }
}
