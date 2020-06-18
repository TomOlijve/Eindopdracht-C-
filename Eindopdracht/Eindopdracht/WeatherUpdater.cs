using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht
{
    class WeatherUpdater
    {
        // haalt het weerinformatie uit de openweathermap api
        public (double temp, string humidity, string mainWeatherInfo, string descriptionWeatherInfo, double windSpeed, string windDirection, string icon) GetWeather(string location, string temperatureUnit)
        {
            using (WebClient web = new WebClient())
            {
                // download de json string van de api
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid=7ac08a4eba5dccaf673f2c1666889e97&units=metric&cnt=6", location);
                var json = web.DownloadString(url);
                dynamic dynamicJson = JsonConvert.DeserializeObject<dynamic>(json);
                // haalt de data uit de json string
                double temp = dynamicJson["main"]["temp"];
                string humidity = dynamicJson["main"]["humidity"].ToString();
                string mainWeatherInfo = dynamicJson["weather"][0]["main"].ToString();
                string descriptionWeatherInfo = dynamicJson["weather"][0]["description"].ToString();
                int windDegrees = (int)dynamicJson["wind"]["deg"];
                double windSpeed = (double)dynamicJson["wind"]["speed"];
                string icon = dynamicJson["weather"][0]["icon"];
                // zet de graden van de wind om in de windrichting
                string windDirection = GetWindDirection(windDegrees);
                // zet de informatie in de database
                UpdateDatabase(temp, location);
                // return alle waarden van het weer
                return (temp, humidity, mainWeatherInfo, descriptionWeatherInfo, windSpeed, windDirection, icon);
            }
        }

        // zet de data van het weer in de database 
        public void UpdateDatabase(double temp, string location)
        {
            try
            {
                // maakt connectie met de database
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\thoma\OneDrive\Documenten\StendenWeerStation.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                // voert de stored procedure AddTodatabase uit
                SqlCommand insertIntoDatabase = new SqlCommand("AddToDatabase", conn);
                insertIntoDatabase.CommandType = CommandType.StoredProcedure;
                // bind de parameters van de stored procedure
                insertIntoDatabase.Parameters.AddWithValue("@Temperature", Convert.ToDecimal(temp));
                insertIntoDatabase.Parameters.AddWithValue("@DateTime", DateTime.Now);
                insertIntoDatabase.Parameters.AddWithValue("@Location", location);
                // execute de stored procedure
                insertIntoDatabase.ExecuteNonQuery();
                // voert de stored procedure DeleteRowsOlderThan5Days uit dit zorgt ervoor dat alle data ouder dan 5 dagen wordt verwijderd uit de database
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

        // berekent de windrichting op basis van de graden 
        public string GetWindDirection(int directionDegrees)
        {
            var degrees = directionDegrees;
            string[] caridnals = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };
            return caridnals[(int)Math.Round(((double)degrees * 10 % 3600) / 225)];
        }
    }
}
