using System;
using System.Collections.Generic;
using System.Text;
using MargieBot;
using Microsoft.ProjectOxford.Face;

namespace MeetDotNet3
{
    public class ImageReponder : IResponder
    {
        string ApiKey;

        public ImageReponder(string apiKey)
        {
            ApiKey = apiKey;
        }
        public bool CanRespond(ResponseContext context)
        {
            return context.Message.Text.StartsWith("<http") && !context.BotHasResponded;
        }

        public BotMessage GetResponse(ResponseContext context)
        {
            BotMessage response = new BotMessage();
            FaceServiceClient client = new FaceServiceClient(ApiKey, "https://westcentralus.api.cognitive.microsoft.com/face/v1.0");

            try
            {
                var faces = client.DetectAsync(context.Message.Text.
                    Replace(">", String.Empty).Replace("<", String.Empty));
                response.Text = $"Na zdjeciu jest {faces.Result.Length} osob";
            }
            catch (Exception e)
            {
                response.Text = "error occured " + e.Message;
            }

            return response;
        }
    }
}
