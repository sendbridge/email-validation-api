// create a free acount at https://app.sendbridge.com/signup
// and get your own API key

// more info in integration https://sendbridge.com/email-validation-api

// Please make sure to include the Newtonsoft.Json namespace and install 
// the Newtonsoft.Json NuGet package if it is not already installed in your 
// project. Also, please note that the dynamic object used for deserialization 
// can be replaced with strongly-typed classes based on the structure of the 
// JSON response for better type safety.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    static async Task Main()
    {
        string apiUrl = "https://api.sendbridge.com/v1/validate/hLxD5h0erBiqmPRbkrjJu4WBdRJI9lMi/tested@emailabc123.com";
        using (var httpClient = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                
                // Deserialize the JSON response into a dynamic object
                dynamic jsonResponse = JsonConvert.DeserializeObject(responseBody);
                
                // Extract data from the dynamic object
                string email = jsonResponse.email;
                bool freemail = jsonResponse.freemail;
                bool validSyntax = jsonResponse.valid_syntax;
                bool abnormalLocalPart = jsonResponse.abnormal_local_part;
                bool abnormalDomain = jsonResponse.abnormal_domain;
                bool localPartTooLong = jsonResponse.local_part_too_long;
                bool shared = jsonResponse.shared;
                bool validTld = jsonResponse.valid_tld;
                bool disposable = jsonResponse.disposable;
                bool mxValid = jsonResponse.mx_valid;
                string aValid = jsonResponse.a_valid;
                int score = jsonResponse.score;
                string timeTaken = jsonResponse.time_taken;
                
                // Display extracted data
                Console.WriteLine("Email: " + email);
                Console.WriteLine("Freemail: " + freemail);
                Console.WriteLine("Valid Syntax: " + validSyntax);
                Console.WriteLine("Abnormal Local Part: " + abnormalLocalPart);
                Console.WriteLine("Abnormal Domain: " + abnormalDomain);
                Console.WriteLine("Local Part Too Long: " + localPartTooLong);
                Console.WriteLine("Shared: " + shared);
                Console.WriteLine("Valid TLD: " + validTld);
                Console.WriteLine("Disposable: " + disposable);
                Console.WriteLine("MX Valid: " + mxValid);
                Console.WriteLine("A Valid: " + aValid);
                Console.WriteLine("Score: " + score);
                Console.WriteLine("Time Taken: " + timeTaken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
