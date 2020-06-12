namespace Eindopdracht
{
    partial class SplashScreen
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
            this.splashScreenImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splashScreenImage)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenImage
            // 
            this.splashScreenImage.Location = new System.Drawing.Point(-1, -2);
            this.splashScreenImage.Name = "splashScreenImage";
            this.splashScreenImage.Size = new System.Drawing.Size(801, 455);
            this.splashScreenImage.TabIndex = 0;
            this.splashScreenImage.TabStop = false;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splashScreenImage);
            this.Name = "SplashScreen";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.splashScreenImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox splashScreenImage;
    }
}

