using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeApp.Services
{
    public class WebClientService : IWebClientService
    {
        public async Task<string> GetString(string uri)
        {
            try
            {
                //HttpClient client = new HttpClient();

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://kushagrajobmanagerapi.azurewebsites.net/api/data/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch
            {
                return null;
            }

        }
    }
}
