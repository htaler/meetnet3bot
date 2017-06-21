using System;
using System.Collections.Generic;
using System.Text;
using MargieBot;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace MeetDotNet3
{
    public class WeatherResponder : IResponder
    {
        string ApiKey;

        public WeatherResponder(string apiKey)
        {
            ApiKey = apiKey;
        }
        public bool CanRespond(ResponseContext context)
        {
            return context.Message.Text.Contains("pogoda");
        }

        public BotMessage GetResponse(ResponseContext context)
        {
            BotMessage response = new BotMessage();

            string city = context.Message.Text.Replace("pogoda ", "");


            string url =
                   $"http://api.openweathermap.org/data/2.5/weather?q={city}&mode=json&units=metric&APPID={ApiKey}";

            response.Text = "Szukales pogody w miescie: " + city;

            string pogoda = String.Empty;

            using (HttpClient client = new HttpClient())
            {
                string json = RetrieveJsonAsync(url, client).Result;
                dynamic jsonData = JObject.Parse(json);
                pogoda = $"Temperatura w tym mieście to {jsonData.main.temp} C";
            }

            response.Text = response.Text + Environment.NewLine + pogoda;

            return response;
        }

        private async System.Threading.Tasks.Task<string> RetrieveJsonAsync(string url, HttpClient client)
        {
            string result = await client.GetStringAsync(url);
            return result;
        }
    }
}
