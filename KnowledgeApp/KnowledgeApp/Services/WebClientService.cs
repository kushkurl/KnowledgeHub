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
            
        public async Task<string> DeleteAsync(string uri)
        {
            try
            {
                //HttpClient client = new HttpClient();

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.DeleteAsync(uri);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> GetAsync(string uri)
        {
            try
            {
                //HttpClient client = new HttpClient();

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                    
                return responseBody;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> PostAsync(string uri, string body, string type)
        {
            try
            {
                //HttpClient client = new HttpClient();

                HttpClient client = new HttpClient();
                var content = new StringContent(body, Encoding.UTF8, type);
                HttpResponseMessage response = await client.PostAsync(uri, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> PutAsync(string uri, string body, string type)
        {
            try
            {
                //HttpClient client = new HttpClient();

                HttpClient client = new HttpClient();
                var content = new StringContent(body, Encoding.UTF8, type);
                HttpResponseMessage response = await client.PutAsync(uri, content);
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
