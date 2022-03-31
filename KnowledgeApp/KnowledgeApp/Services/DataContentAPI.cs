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
        private static string API => $"https://kushagrajobmanagerapi.azurewebsites.net/";

        public async Task<List<DataContent>> GetData(int cId)
        {
            var jsonString = await new WebClientService().GetAsync(API + "api/"+ cId +"/data/");
            var data = JsonConvert.DeserializeObject<List<DataContent>>(jsonString);
            return data;
            //throw new NotImplementedException();
        }
        public async Task<DataContent> GetData(DataContent DataObj)
        {
            var jsonString = await new WebClientService().GetAsync(API + "api/data/" + DataObj.id);
            var data = JsonConvert.DeserializeObject<DataContent>(jsonString);
            return data;
            //throw new NotImplementedException();
        }

        public async Task<DataContent> Delete(DataContent data)
        {
            var jsonString = await new WebClientService().DeleteAsync(API + "api/data/" + data.id);
            var resp = JsonConvert.DeserializeObject<DataContent>(jsonString);
            return resp;
        }
        public async Task<DataContent> Update(DataContent data)
        {
            string payload = JsonConvert.SerializeObject(data);                                                                                 
            var jsonString = await new WebClientService().PutAsync(API + "api/data/" + data.id, payload, "application/json");
            var resp = JsonConvert.DeserializeObject<DataContent>(jsonString);
            return resp;
        }
        public async Task<DataContent> Add(DataContent data)
        {
            string payload = JsonConvert.SerializeObject(data);
            var jsonString = await new WebClientService().PostAsync(API + "api/data/" + data.id, payload, "application/json");
            var resp = JsonConvert.DeserializeObject<DataContent>(jsonString);
            return resp;
        }

        public async Task<List<Category>> GetCategory()
        {
            var jsonString = await new WebClientService().GetAsync(API + "api/Category");
            var data = JsonConvert.DeserializeObject<List<Category>>(jsonString);
            return data;
        }
    }
}
