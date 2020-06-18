using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Web;
using System.Threading;
using System.Net;
using Newtonsoft.Json;
using NPlot;
using MySql;
using System.Runtime.CompilerServices;

namespace WeatherStation
{
    public partial class Form1 : Form
    {
        string City = "Emmen";
        int IntervalInSec = 60000;
        int closeApp = 0;

        public Form1()
        {
            // Thread voor splashscreen
            Thread t = new Thread(new ThreadStart(SplashStart));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
            getData();
        }

        public void SplashStart() 
        {
            // Splashscreen op Form2
            Application.Run(new Form2());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // grafiek inladen
            setGraph1();
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // About pagina
            AboutBox1 frmAbout = new AboutBox1();
            frmAbout.Show();
        }

        
        private void overToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 frmAbout = new AboutBox1();
            frmAbout.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntervalInSec = Int32.Parse(textBox2.Text) * 1000;
            timer1.Interval = IntervalInSec;
            City = textBox1.Text;
            getData();
        }

        private async void getData()
        {
            Uri url = new Uri("http://api.openweathermap.org/data/2.5/weather?q=" + City + "&mode=json&units=metric&APPID=d96bc38a2ea54519151ca912cad7b829");
            WebClient wc = new WebClient();
            string json = await wc.DownloadStringTaskAsync(url);
            OpenWeather value = JsonConvert.DeserializeObject<OpenWeather>(json);

            string result = DegreesToCardinalDetailed(value.Wind.Direction);
            double temp = value.WeatherData.Temperature;
            if(celcius.Checked)
            { 
                label7.Text = temperature(temp).ToString() + " °C";
                huidigeTemperatuurToolStripMenuItem.Text = "Huidige temperatuur is: " + temperature(temp).ToString() + " °C";
            }
            else if(fahrenheit.Checked)
            {
                label7.Text = temperature(temp).ToString() + " °F";
                huidigeTemperatuurToolStripMenuItem.Text = "Huidige temperatuur is: " + temperature(temp).ToString() + " °F";
            }




            label8.Text = value.WeatherData.Humidity.ToString();
            label9.Text = value.Wind.Speed.ToString() + "  " + result;
            label5.Text = value.CityName.ToString();
            label6.Text = value.Weather[0].Description.ToString();

            double updateTime = value.Time;
            label4.Text = "Laatste geupdatet: " + UnixTimeStampToDateTime(updateTime).ToString();
            
            string icon = value.weather[0].icon.ToString();
            var iconRequest = WebRequest.Create("http://openweathermap.org/img/w/" +  icon + ".png");
            using (var iconResponse = iconRequest.GetResponse())
            using (var iconStream = iconResponse.GetResponseStream())
            {
                this.icon.Image = Bitmap.FromStream(iconStream);
            }

            textBox2.Text = (IntervalInSec / 1000).ToString();
            textBox1.Text = City;

            addToDB(temp);
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public double temperature(double temp)
        {
            if(celcius.Checked)
            {
                double celsius = (temp);
                    return celsius;
            }
            else if(fahrenheit.Checked)
            {
                double fahrenheit = (temp * 1.8 + 32);
                    return fahrenheit;
            }
            else
            {
                return temp;
            }
        }


        public static string DegreesToCardinalDetailed(double degrees)
        {
            degrees *= 10;

            string[] cardinals = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };
            return cardinals[(int)Math.Round(((double)degrees % 3600) / 225)];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getData();

        }

        private void sluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeApp = 1;
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeApp == 1)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            }
        }

        private void optiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            tabControl1.SelectedTab = tabPage3;
            ShowInTaskbar = true;
        }

        private void verversenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void addToDB(double temp)
        {
            MySql.Data.MySqlClient.MySqlConnection connect;
            MySql.Data.MySqlClient.MySqlCommand cmd;

            connect = new MySql.Data.MySqlClient.MySqlConnection();
            cmd = new MySql.Data.MySqlClient.MySqlCommand();

            DateTime time = new DateTime();
            time = DateTime.Now;
            string time2 = time.ToString("yyyy-MM-dd");

            connect.ConnectionString = "server=localhost;uid=root;pwd=;database=csharp;";
            string query = "INSERT INTO `weergegevens`(`temperatuur`, `plaats`, `datum`) VALUES ('"+temp+"', '"+City+"', '"+time2+"')";

            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                connect.Clone();
            }
            catch (MySql.Data.MySqlClient.MySqlException except)
            {
                MessageBox.Show(except.Message);
                throw;
            }
        }

        private void setGraph1()
        {
            // clear the surface
            plotSurface2D1.Clear();

            // Add a background grid.
            Grid grid = new Grid();
            grid.VerticalGridType = Grid.GridType.Coarse;
            grid.HorizontalGridType = Grid.GridType.Coarse;
            grid.MajorGridPen = new Pen(Color.LightGray, 1.0f);

            plotSurface2D1.Add(grid);

            // Create a step plot instance for the sineX chart.
            LinePlot stpSineX = new LinePlot();
            // choose Pen colour and size
            stpSineX.Pen = new Pen(Color.Blue, 2);

            // Create the lists from which to get the data.
            List<double> YAxis = new List<double>();
            List<DateTime> XAxis = new List<DateTime>();

            MySql.Data.MySqlClient.MySqlConnection connect;
            MySql.Data.MySqlClient.MySqlCommand cmd;

            connect = new MySql.Data.MySqlClient.MySqlConnection();
            cmd = new MySql.Data.MySqlClient.MySqlCommand();

            connect.ConnectionString = "server=localhost;uid=root;pwd=;database=csharp;";

            DateTime date = new DateTime();
            int count = 1;
            while(count < 6)
            {
                string datum;
                List<double> temperatuurvalue = new List<double>();
                connect.Open();
                cmd.Connection = connect;

                date = DateTime.Now.AddDays(-count);
                datum = date.ToString("yyyy-MM-dd");

                string query = "SELECT `temperatuur` FROM `weergegevens` WHERE `plaats` = '" + City + "' AND `datum` = '" + datum + "'";

                cmd.CommandText = query;
                MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows == false)        
                {
                    temperatuurvalue.Add(0);
                }
                else
                {
                    while(reader.Read())
                    {
                        double tempData = (double)reader[0];
                        temperatuurvalue.Add(tempData);
                    }
                }
                connect.Close();
                double average = temperatuurvalue.Average();
                XAxis.Add(date);
                YAxis.Add(average);
                count++;
            }                      

            // Set the x-axis (abscissa) and datasource for the plot.
            stpSineX.AbscissaData = XAxis;
            stpSineX.DataSource = YAxis;

            // Add the stpSineX to plot.
            plotSurface2D1.Add(stpSineX);

            // Plot general settings.
            plotSurface2D1.ShowCoordinates = true;
            plotSurface2D1.YAxis1.Label = "Gemiddelde temperatuur";
            plotSurface2D1.YAxis1.LabelOffsetAbsolute = true;
            plotSurface2D1.YAxis1.LabelOffset = 40;
            plotSurface2D1.XAxis1.HideTickText = false; // true;
            plotSurface2D1.Padding = 5;
            
            // Refresh surface.
            plotSurface2D1.Refresh();
        }
    }
}
