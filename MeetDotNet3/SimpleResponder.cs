using System;
using System.Collections.Generic;
using System.Text;
using MargieBot;

namespace MeetDotNet3
{
    public class SimpleResponder : IResponder
    {
        public bool CanRespond(ResponseContext context)
        {
            return context.Message.Text.Contains("hello");
        }

        public BotMessage GetResponse(ResponseContext context)
        {
            BotMessage response = new BotMessage();
            response.Text = "Hello " + context.Message.User.FormattedUserID;
            return response;
        }
    }
}
