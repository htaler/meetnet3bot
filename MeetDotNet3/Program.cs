using System;
using MargieBot;

namespace MeetDotNet3
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot myBot = new Bot();
            myBot.Connect("xoxb-tutaj podaj swoj api key");
            myBot.RespondsTo("piwo").With("nie ma piwa");
            myBot.RespondsTo("jarek").With("dla ciebie pan Jarek").With("Jaki Jarek?");
            myBot.Responders.Add(new SimpleResponder());
            myBot.Responders.Add(new WeatherResponder("xxx-tutaj podaj swoj api key"));
            myBot.Responders.Add(new ImageReponder("xxx-tutaj podaj swoj api key"));
            Console.ReadKey();
        }
    }
}