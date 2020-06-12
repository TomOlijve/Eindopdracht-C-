using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Data.Common;
using System.Diagnostics;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Dynamic;
using System.Drawing.Drawing2D;

namespace Eindopdracht
{
    public partial class MainPage : Form
    {
        private TabControl tabControl { get; set; }
        private TabPage actueel { get; set; }
        private TabPage trend { get; set; }
        private TabPage opties { get; set; }
        private Timer timer { get; set; }
        private NotifyIcon notifyIcon { get; set; }
        private string city { get; set; }
        private Label currentTemperature;
        private Label currentHumidity;
        private Label currentWeatherInfo;
        private Label lastUpdated;
        private string temperatureUnit;

        public MainPage()
        {
            InitializeComponent();
            this.Height = 480;
            this.Width = 720;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.CenterToScreen();
            this.tabControl = new TabControl() { Height = this.Height, Width = this.Width };
            this.Controls.Add(tabControl);
            this.actueel = new TabPage() { Height = this.Height, Width = this.Width, Text = "Actueel", BackColor = Color.FromArgb(90, 90, 90) };
            this.trend = new TabPage() { Height = this.Height, Width = this.Width, Text = "Trend", BackColor = Color.FromArgb(90, 90, 90) };
            this.opties = new TabPage() { Height = this.Height, Width = this.Width, Text = "Opties", BackColor = Color.FromArgb(90, 90, 90) };
            this.tabControl.Controls.Add(actueel);
            this.currentTemperature = new Label() { Location = new Point(50, 50), Font = new Font("Arial", 12), ForeColor = Color.White };
            this.currentHumidity = new Label() { Location = new Point(50, 100), Font = new Font("Arial", 12), ForeColor = Color.White };
            this.currentWeatherInfo = new Label() { Location = new Point(50, 150), Font = new Font("Arial", 12), AutoSize = true, ForeColor = Color.White };
            this.lastUpdated = new Label() { Location = new Point(50, 200), Font = new Font("Arial", 12), AutoSize = true, ForeColor = Color.White };
            this.actueel.Controls.Add(currentTemperature);
            this.actueel.Controls.Add(currentHumidity);
            this.actueel.Controls.Add(currentWeatherInfo);
            this.actueel.Controls.Add(lastUpdated);
            this.tabControl.Controls.Add(trend);
            this.tabControl.Controls.Add(opties);
            this.city = "Emmen";
            GetWeather();
            Timer timer = new Timer();
            timer.Tick += Timer_Update;
            timer.Interval = 5000;
            timer.Start();
        }

        public void Timer_Update(Object sender, EventArgs e)
        {
            GetWeather();
        }

        public void GetWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid=7ac08a4eba5dccaf673f2c1666889e97&units=metric&cnt=6", this.city);
                var json = web.DownloadString(url);
                dynamic dynamicJson = JsonConvert.DeserializeObject<dynamic>(json);
                string temp = dynamicJson["main"]["temp"].ToString();
                string humidity = dynamicJson["main"]["humidity"].ToString();
                string mainWeatherInfo = dynamicJson["weather"][0]["main"].ToString();
                string descriptionWeatherInfo = dynamicJson["weather"][0]["description"].ToString();
                if (temperatureUnit == "fahrenheit")
                {
                    this.currentTemperature.Text = ((Convert.ToDouble(temp) * 1.8) + 32).ToString() + " °F";
                }
                else
                {
                    this.currentTemperature.Text = temp + " °C";
                }
                this.currentHumidity.Text = humidity;
                this.currentWeatherInfo.Text = mainWeatherInfo + ", " + descriptionWeatherInfo;
                this.lastUpdated.Text = DateTime.Now.ToString();
                try
                {
                    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\thoma\OneDrive\Documenten\StendenWeerStation.mdf;Integrated Security=True;Connect Timeout=30";
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();

                    Console.WriteLine(Convert.ToDecimal(temp));
                    SqlCommand insertIntoDatabase = new SqlCommand("AddToDatabase", conn);
                    insertIntoDatabase.CommandType = CommandType.StoredProcedure;
                    insertIntoDatabase.Parameters.AddWithValue("@Temperature", Convert.ToDecimal(temp));
                    insertIntoDatabase.Parameters.AddWithValue("@DateTime", DateTime.Now);
                    insertIntoDatabase.Parameters.AddWithValue("@Location", this.city);
                    insertIntoDatabase.ExecuteNonQuery();
                    SqlCommand deleteFromDatabaseOlderThan5Days = new SqlCommand("DeleteRowsOlderThan5Days", conn);
                    deleteFromDatabaseOlderThan5Days.CommandType = CommandType.StoredProcedure;
                    deleteFromDatabaseOlderThan5Days.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
