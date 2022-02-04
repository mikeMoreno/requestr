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
            this.SuspendLayout();
            // 
            // comboMethod
            // 
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
            this.textUrl.Location = new System.Drawing.Point(95, 33);
            this.textUrl.Name = "textUrl";
            this.textUrl.Size = new System.Drawing.Size(515, 23);
            this.textUrl.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(616, 32);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // RequestPanel
            // 
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.comboMethod);
            this.Controls.Add(this.textUrl);
            this.Location = new System.Drawing.Point(3, 3);
            this.Name = "RequestPanel";
            this.Size = new System.Drawing.Size(1069, 917);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ComboBox comboMethod;
        private TextBox textUrl;

        #endregion

        private Button btnSend;
    }
}
