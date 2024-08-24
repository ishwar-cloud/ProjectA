using Amantran.Models;
using System.ComponentModel;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Amantran.BuscinessServices.Implimentation
{
    public interface IFacebookApiService
    {
        // Task SendMessageAsync(string phoneNumber, string templateName);
        Task SendMessageAsync(List<SendMessageModel> messageData);

    }

    public class FacebookApiService : IFacebookApiService
    {
        private readonly HttpClient _httpClient;

        public FacebookApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task SendMessageAsync(List<SendMessageModel> messageData)
        {
            string accessToken = "EAAL6HvWsmooBO8kww1m6i1w5lLz0jLCt2i9BoJInG5ZAzZArZCNdJ2Dihewf7qEmkbZBc4BwSwd5aiiFhOuwMKZAqhWl56NunrEuSRkNaQAYDyMrnZASSZB56LeT8AWoz1BmpdBllN0DgxoZALgkyc59grY9vM0On10DOM5TJCt0aUZBQGXC6e9P6jAXMbO1tqZB4G2P331ZAmapCBMg50hQZCiQibQo4azZChzbDP8vyADX2M0MZD"; // Replace with your actual access token

            foreach (var data in messageData)
            {

                // Parse the variable_sequence into a list of field names
                var fields = data.variable_sequence.Split(',');

                // Use a dictionary to map field names to their sanitized values
                var parameters = new Dictionary<string, string>();

                foreach (var field in fields)
                {
                  

                   var fieldValue = typeof(SendMessageModel).GetProperty(field)?.GetValue(data) as string;
                    if (fieldValue != null)
                    {
                        parameters[field] = SanitizeText(fieldValue);
                    }
                    else
                    {
                        // Log if any field is missing or has null value
                        Console.WriteLine($"Warning: Field {field} is missing or has a null value.");
                    }
                }

                // Construct the message content dynamically
                var messageContent = new
                {
                    messaging_product = "whatsapp",
                    to = data.whatsapp_number,
                    type = "template",
                    template = new
                    {
                        name = "test_template", // Replace with your actual template name
                        language = new { code = "en" },
                        components = new[]
                        {
                    new
                    {
                        type = "body",
                        parameters = fields.Select(field => new
                        {
                            type = "text",
                            text = parameters.ContainsKey(field) ? parameters[field] : string.Empty
                        }).ToArray()
                    }
                }
                    }
                };

                // Log the message content for debugging
                Console.WriteLine($"Sending message: {JsonSerializer.Serialize(messageContent)}");

                var request = new HttpRequestMessage(HttpMethod.Post, "https://graph.facebook.com/v20.0/136940536164243/messages")
                {
                    Headers =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
            },
                    Content = new StringContent(JsonSerializer.Serialize(messageContent), Encoding.UTF8, "application/json")
                };

                var response = await _httpClient.SendAsync(request);

                // Log response content for debugging
                var responseContent = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error response: {responseContent}");
                    throw new HttpRequestException($"Error sending message to {data.whatsapp_number}: {response.StatusCode} - {responseContent}");
                }
            }
        }
        private string SanitizeText(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // Remove newlines, tabs, and reduce multiple spaces to a single space
            return Regex.Replace(input, @"[\n\r\t]+", " ")
                        .Replace("  ", " ")
                        .Trim();
        }


       

    }
}