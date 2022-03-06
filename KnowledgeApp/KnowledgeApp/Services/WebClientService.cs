using System;
using System.Collections.Generic;
using System.Net.Http;
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
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(uri);

                return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null;
            }
            catch
            {
                return null;
            }

        }
    }
}
