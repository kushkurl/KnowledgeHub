using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeApp.Services
{
    public interface IWebClientService
    {
        //Task<string> GetString(string uri);
        Task<string> GetAsync(string uri);
        Task<string> PostAsync(string uri, string body, string type);
        Task<string> PutAsync(string uri, string body, string type);
        Task<string> DeleteAsync(string uri);
    }
}
