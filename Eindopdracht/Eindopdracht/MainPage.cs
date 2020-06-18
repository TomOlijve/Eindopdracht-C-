using System;
using System.Data;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.IO;

namespace Eindopdracht
{
    public partial class MainPage : Form
    {
        public Timer Timer { get; set; }
        public string Location { get; set; }
        public int Interval { get; set; }
        public string TemperatureUnit { get; set; }
        public About About { get; set; }
        public Timer UpdateTimer { get; set; }
        private WeatherUpdater WeatherUpdater { get; set; }
        public double Temperature { get; set; }

        public MainPage()
        {
            InitializeComponent();
            // centered de applicatie en zorgt ervoor dat de maximize knop niet meer beschikbaar is
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.CenterToScreen();
            GetSettings();
            FillChart();
            // maakt de klasse aan die de weerinformatie opvraagt
            this.WeatherUpdater = new WeatherUpdater();
            UpdateWeather ();
            //start de timer die de weerinformatie update en het naar de database stuurt
            this.UpdateTimer = new Timer();
            this.UpdateTimer.Tick += Timer_Update;
            this.UpdateTimer.Interval = this.Interval;
            this.UpdateTimer.Start();
        }

        // haalt de settings uit het json bestand en update de fields en radiobuttons
        public void GetSettings()
        {
            // haalt de instellingen uit het json bestand
            string settingsJsonLocation = File.ReadAllText("../../Settings.Json");
            dynamic settingsJson = JsonConvert.DeserializeObject<dynamic>(settingsJsonLocation);
            // update de field en de radiobuttons
            this.Location = settingsJson["location"];
            this.TemperatureUnit = settingsJson["temperatureUnit"];
            if(this.TemperatureUnit == "C")
            {
                this.temperatureUnit_Celsius.Checked = true;
            }
            else
            {
                this.temperatureUnit_Fahrenheit.Checked = true;
            }
            this.Interval = settingsJson["interval"];
        }

        // update de instellingen als er op de knop wordt geklikt in opties
        public void UpdateSettings(Object sender, EventArgs e)
        {
            // checkt of de invoervelden niet leeg zijn
            if(this.locationInput.Text != "" && this.intervalInput.Text != "")
            {
                // update het json bestand en de fields
                string settingsJsonLocation = File.ReadAllText("../../Settings.Json");
                dynamic settingsJson = JsonConvert.DeserializeObject<dynamic>(settingsJsonLocation);
                settingsJson["location"] = this.locationInput.Text;
                this.Location = this.locationInput.Text;
                settingsJson["interval"] = int.Parse(this.intervalInput.Text) * 1000;
                this.Interval = int.Parse(this.intervalInput.Text) * 1000;
                this.UpdateTimer.Interval = this.Interval;
                if (this.temperatureUnit_Celsius.Checked)
                {
                    settingsJson["temperatureUnit"] = "C";
                    this.TemperatureUnit = "C";
                }
                else
                {
                    settingsJson["temperatureUnit"] = "F";
                    this.TemperatureUnit = "F";
                }
                // schrijft de veranderingen naar het json bestand
                string settingsJsonSerialized = JsonConvert.SerializeObject(settingsJson);
                File.WriteAllText("../../Settings.json", settingsJsonSerialized);
                WeatherUpdater.GetWeather(this.Location, this.TemperatureUnit); 
            }
            else
            {
                // laat een messagebox zien als de velden niet ingevuld zijn
                System.Windows.Forms.MessageBox.Show("vul alle invoervelden in");
            }
        }

        // deze functie wordt aangeroepen door de timer bij de tick
        public void Timer_Update(Object sender, EventArgs e)
        {
            // update het weer in de app en het notifyicon
            UpdateWeather();
            // update de chart als mainform open is
            if(this.Visible == true)
            {
                UpdateChart();
            }
        }

        // update het weer in de applicatie
        public void UpdateWeather()
        {
            // vraagt het weer op basis van de locatie en welke temperatuur eenheid er wordt gebruikt
            var weatherUpdateValues = WeatherUpdater.GetWeather(this.Location, this.TemperatureUnit);
            // als de temperatuureinheid fahrenheit is wordt celsius omgerekend naar fahrenheit
            if (TemperatureUnit == "F")
            {
                 this.Temperature = ((weatherUpdateValues.temp * 1.8) + 32);
            }
            else
            {
                this.Temperature = weatherUpdateValues.temp;
            }
            // update de labels en de icon in actueel en het weer in de notifyicon
            this.currentTemperature.Text = this.Temperature + " °" + this.TemperatureUnit;
            this.currentHumidity.Text = weatherUpdateValues.humidity;
            this.currentWeatherInfo.Text = weatherUpdateValues.mainWeatherInfo + ", " + weatherUpdateValues.descriptionWeatherInfo;
            this.currentWindDirection.Text = weatherUpdateValues.windDirection;
            this.currentWindSpeed.Text = weatherUpdateValues.windSpeed.ToString();
            this.lastUpdated.Text = DateTime.Now.ToString();
            this.currentLocation.Text = this.Location;
            this.contextMenu.Items["currentTemperatureToolStripMenuItem"].Text = "Temperature: " + this.Temperature + " °" + this.TemperatureUnit;
            // vraagt de afbeelding op van de icon 
            var iconRequest = WebRequest.Create("http://openweathermap.org/img/w/" +  weatherUpdateValues.icon + ".png");
            using (var iconResponse = iconRequest.GetResponse())
            using (var iconStream = iconResponse.GetResponseStream())
            {
                this.currentIcon.Image = Bitmap.FromStream(iconStream);
            }
        }

        // vult de chart met de informatie uit de database
        public void FillChart()
        {
            // verbinding met de database maken
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\thoma\OneDrive\Documenten\StendenWeerStation.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            // dit haalt de temperatuur uit de database van de afgelopen 5 dagen op de locatie die de gebruiker heeft ingesteld
            SqlCommand getWeatherFromDb = new SqlCommand("GetChartData", conn);
            getWeatherFromDb.CommandType = CommandType.StoredProcedure;
            getWeatherFromDb.Parameters.AddWithValue("@Location", this.Location);
            var reader = getWeatherFromDb.ExecuteReader();
            // zet de x as in het formaat dd-mm-yyyy
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "dd-mm-yyyy";
            chart.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = true;
            chart.ChartAreas[0].AxisY.LabelStyle.IsEndLabelVisible = true;
            chart.ChartAreas[0].AxisX.Maximum = 5;
            chart.ChartAreas[0].AxisX.Minimum = 1;
            // zet de punten in de chart
            while (reader.Read())
            {
                string date = reader["Date"].ToString().Split()[0];
                Console.WriteLine(date);
                chart.Series["Temperature"].Points.AddXY(date, reader["Temp"]);
            }
            conn.Close();
        }

        //update de chart door eerst de punten te verwijderen en dan de punten weer in te voeren
        public void UpdateChart()
        {
            this.chart.Series["Temperature"].Points.Clear();
            FillChart();
        }

        // als de form wordt afgesloten wordt de applicatie niet afgesloten zodat de notifyicon nog steeds zichtbaar blijft
        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            // canceled het afsluiten van de appliatie
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            this.ShowInTaskbar = false;
            notifyIcon1.Visible = true;
        }

        // ververst het weer in de applicatie
        private void verversenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateWeather();
        }

        // brengt de gebruiker naar het opties tablad
        private void optiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.ShowInTaskbar = true;
            tabControl.SelectTab("opties");
        }

        // opent de applicatie
        private void openenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.ShowInTaskbar = true;
        }
           
        // sluit de applicatie
        private void sluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.Visible)
            {
                this.Close();
            }
            System.Windows.Forms.Application.Exit();
        }

        // opent het over form
        private void overToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // opent de about alleen als hij nog niet open is
            if(this.About == null)
            {
                this.About = new About();
                this.About.Visible = true;
            }
            //als de about als open is wordt hij naar voren gebracht
            else
            {
                this.About.WindowState = FormWindowState.Normal;
                this.About.Focus();
            }
        }
    }
}
