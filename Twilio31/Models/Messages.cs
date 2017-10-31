using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace Twilio31.Models
{
    public class Message
    {   [Key]
        public int MessageId { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }
        public string Date_Sent { get; set; }

        public static List<Message> GetMessages()
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/ACbdad9a7a5b65ad655c501ef37ee0375f/Messages.json", Method.GET);
            client.Authenticator = new HttpBasicAuthenticator("ACbdad9a7a5b65ad655c501ef37ee0375f", "ac924cd3e5aca5f62680c3f4f0e16721");
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse["messages"].ToString());
            return messageList;
        }

        public void Send()
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/ACbdad9a7a5b65ad655c501ef37ee0375f/Messages", Method.POST);
            request.AddParameter("To", To);
            request.AddParameter("From", From);
            request.AddParameter("Body", Body);
            client.Authenticator = new HttpBasicAuthenticator("ACbdad9a7a5b65ad655c501ef37ee0375f", "ac924cd3e5aca5f62680c3f4f0e16721");
            client.ExecuteAsync(request, response => {
                Console.WriteLine(response.Content);
            });
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}