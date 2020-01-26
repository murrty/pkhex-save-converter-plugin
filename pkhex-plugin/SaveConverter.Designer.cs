namespace SaveConverter
{
    partial class SaveConverter
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbInfo = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lbDSInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbInfo
            // 
            this.lbInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.Location = new System.Drawing.Point(12, 10);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(328, 24);
            this.lbInfo.TabIndex = 2;
            this.lbInfo.Text = "Select a .sav or .dsv file to convert";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbInfo.Visible = false;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(139, 80);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "Convert file";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Visible = false;
            this.btnConvert.Click += new System.EventHandler(this.ConvertFile);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(265, 80);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.DisposeForm);
            // 
            // lbDSInfo
            // 
            this.lbDSInfo.Location = new System.Drawing.Point(12, 40);
            this.lbDSInfo.Name = "lbDSInfo";
            this.lbDSInfo.Size = new System.Drawing.Size(328, 27);
            this.lbDSInfo.TabIndex = 5;
            this.lbDSInfo.Text = "Only DS games can be converted (Gen 4 && Gen 5)\r\nThis will replace the file with " +
    "the converted one.";
            this.lbDSInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbDSInfo.Visible = false;
            // 
            // SaveConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(352, 115);
            this.Controls.Add(this.lbDSInfo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.lbInfo);
            this.MaximizeBox = false;
            this.Name = "SaveConverter";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DS Save Editor Converter";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lbDSInfo;
    }
}
