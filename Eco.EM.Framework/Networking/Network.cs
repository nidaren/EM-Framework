using Eco.EM.Framework.Logging;
using Eco.Shared.Properties;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using StrangeCloud.Service.Client.Contracts; //added but may not be needed
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Framework.Networking
{
    public static class Network
    {
        private static readonly HttpClient httpClient = new();
        private readonly static string jsonMediaType = "application/json";


        public static string GetRequest(string URL) //changed to synchronous instead of async
        {
            try
            {
                httpClient.BaseAddress = new Uri(URL);
                var result = httpClient.GetStringAsync(httpClient.BaseAddress);
                return result.Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static async Task<string> PostRequestAsync(string URL, Dictionary<string, string> Parameters)
        {
            try
            {
                httpClient.BaseAddress = new Uri(URL);

                var PostData = string.Empty;

                foreach (var param in Parameters)
                {
                    if (!string.IsNullOrWhiteSpace(PostData))
                    {
                        PostData += "&";
                    }

                    PostData += $"{param.Key}={param.Value}";
                }

                StringContent strContent = new(PostData, Encoding.UTF8, jsonMediaType);
                HttpResponseMessage responseMessage = await httpClient.PostAsync(httpClient.BaseAddress, strContent).ConfigureAwait(false);
                return await responseMessage.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static async Task<string> PostRequest(string URL, string PostData)
        {
            try
            {
                httpClient.BaseAddress = new Uri(URL);
                LoggingUtils.Debug(PostData);

                StringContent strContent = new(PostData, Encoding.UTF8, jsonMediaType); // Simplified declaration
                HttpResponseMessage responseMessage = await httpClient.PostAsync(httpClient.BaseAddress, strContent).ConfigureAwait(false);
                return await responseMessage.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        //Added method to convert the HttpResponse to string
        //All of the following changes were in an attempt to get the Framework to stop making hte webserver not load.
        //Left changes as they did update the methods to more modern methods
        public static string ContentToString(this Task<HttpResponseMessage> httpContent)
        {
            var readAsStringAsync = httpContent.ContentToString();
            return readAsStringAsync;
        }

        public static string PostRequestResponse(string URL, Dictionary<string, string> Parameters)
        {
            try
            {
                if (Parameters != null)
                    foreach (var parameter in Parameters)
                    {
                        URL += (URL.Contains("?")) ? "&" : "?";
                        URL += $"{parameter.Key}={parameter.Value}";
                    }

                using HttpClient client = new(); //updated to using HttpClient to get away from outdated Webclient
                string result = ContentToString(client.PostAsync(URL, content: null)); //Sent result to contenttostring method to convert to string
                return result;//Return result as string
            }
            catch (Exception e)
            {
                return URL + " " + e.Message;
            }
        }
    }
}