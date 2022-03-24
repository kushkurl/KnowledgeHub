using KnowledgeApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeApp.Services
{
    public class DataContentAPI : IRestService
    {
        private static string API => $"https://kushagrajobmanagerapi.azurewebsites.net/api/data";

        public async Task<List<DataContent>> GetData()
        {
            var jsonString = await new WebClientService().GetAsync(API);
            var data = JsonConvert.DeserializeObject<List<DataContent>>(jsonString);
            return data;
            //throw new NotImplementedException();
        }
        public async Task<DataContent> GetData(int id)
        {
            var jsonString = await new WebClientService().GetAsync(API + "/"+id);
            var data = JsonConvert.DeserializeObject<DataContent>(jsonString);
            return data;
            //throw new NotImplementedException();
        }

        public async Task<DataContent> Delete(DataContent data)
        {
            var jsonString = await new WebClientService().DeleteAsync(API + "/" + data.id);
            var resp = JsonConvert.DeserializeObject<DataContent>(jsonString);
            return resp;
        }
        public async Task<DataContent> Update(DataContent data)
        {
            var jsonString = await new WebClientService().PutAsync(API + "/" + data.id, "test", "application/json");
            var resp = JsonConvert.DeserializeObject<DataContent>(jsonString);
            return resp;
        }
        public async Task<DataContent> Add(DataContent data)
        {
            var jsonString = await new WebClientService().PostAsync(API + "/" + data.id, "test", "application/json");
            var resp = JsonConvert.DeserializeObject<DataContent>(jsonString);
            return resp;
        }
    }
}
