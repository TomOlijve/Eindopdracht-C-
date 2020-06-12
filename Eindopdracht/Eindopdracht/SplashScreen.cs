using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eindopdracht
{
    public partial class SplashScreen : Form
    {
        Timer timer;
        public SplashScreen()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Height = 300;
            this.Width = 500;
            this.CenterToScreen();
            splashScreenImage.Image = Image.FromFile("C:/Users/thoma/source/repos/Eindopdracht/Eindopdracht/img/splashscreen.jpg");
            splashScreenImage.Width = this.Width;
            splashScreenImage.Height = this.Height;
            Label centerLabel = new Label() { Text = "Stenden Weerstation", ForeColor = Color.White, BackColor = Color.Transparent, Font = new Font("Arial", 16, FontStyle.Bold), Size = new Size(100, 50), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill};
            this.splashScreenImage.Controls.Add(centerLabel);
            timer = new Timer();
            timer.Interval = 2000;
            timer.Start();
            timer.Tick += timer_Tick;
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            MainPage mainPage = new MainPage();
            this.Hide();
            mainPage.Show();
        }
    }
}
