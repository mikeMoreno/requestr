﻿namespace Requestr.Forms
{
    partial class ResponseBodyPanel
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
            this.txtBody = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtBody
            // 
            this.txtBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBody.Location = new System.Drawing.Point(0, 0);
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(690, 298);
            this.txtBody.TabIndex = 0;
            this.txtBody.Text = "";
            // 
            // ResponseBodyPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtBody);
            this.Name = "ResponseBodyPanel";
            this.Size = new System.Drawing.Size(690, 298);
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox txtBody;
    }
}
