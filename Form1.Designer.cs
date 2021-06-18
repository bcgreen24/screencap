namespace screenCap
{
    partial class frmScreenCapMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScreenCapMain));
            this.btnTakeScreenshot = new System.Windows.Forms.Button();
            this.imageDisplay = new System.Windows.Forms.PictureBox();
            this.txtCaptureDirectory = new System.Windows.Forms.TextBox();
            this.btnGetCaptureDirectory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTakeScreenshot
            // 
            this.btnTakeScreenshot.Location = new System.Drawing.Point(12, 124);
            this.btnTakeScreenshot.Name = "btnTakeScreenshot";
            this.btnTakeScreenshot.Size = new System.Drawing.Size(307, 39);
            this.btnTakeScreenshot.TabIndex = 0;
            this.btnTakeScreenshot.Text = "&Take Screenshot";
            this.btnTakeScreenshot.UseVisualStyleBackColor = true;
            // 
            // imageDisplay
            // 
            this.imageDisplay.Location = new System.Drawing.Point(12, 172);
            this.imageDisplay.Name = "imageDisplay";
            this.imageDisplay.Size = new System.Drawing.Size(307, 217);
            this.imageDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageDisplay.TabIndex = 1;
            this.imageDisplay.TabStop = false;
            // 
            // txtCaptureDirectory
            // 
            this.txtCaptureDirectory.Location = new System.Drawing.Point(12, 94);
            this.txtCaptureDirectory.Name = "txtCaptureDirectory";
            this.txtCaptureDirectory.Size = new System.Drawing.Size(242, 20);
            this.txtCaptureDirectory.TabIndex = 2;
            // 
            // btnGetCaptureDirectory
            // 
            this.btnGetCaptureDirectory.Location = new System.Drawing.Point(261, 95);
            this.btnGetCaptureDirectory.Name = "btnGetCaptureDirectory";
            this.btnGetCaptureDirectory.Size = new System.Drawing.Size(58, 23);
            this.btnGetCaptureDirectory.TabIndex = 3;
            this.btnGetCaptureDirectory.Text = "...";
            this.btnGetCaptureDirectory.UseVisualStyleBackColor = true;
            this.btnGetCaptureDirectory.Click += new System.EventHandler(this.btnGetCaptureDirectory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Capture Directory";
            // 
            // frmScreenCapMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 401);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetCaptureDirectory);
            this.Controls.Add(this.txtCaptureDirectory);
            this.Controls.Add(this.imageDisplay);
            this.Controls.Add(this.btnTakeScreenshot);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmScreenCapMain";
            this.Text = "screenCap";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)(this.imageDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTakeScreenshot;
        private System.Windows.Forms.PictureBox imageDisplay;
        private System.Windows.Forms.TextBox txtCaptureDirectory;
        private System.Windows.Forms.Button btnGetCaptureDirectory;
        private System.Windows.Forms.Label label1;
    }
}

