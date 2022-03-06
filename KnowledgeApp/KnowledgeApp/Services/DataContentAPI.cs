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
        public async Task<List<DataContent>> GetData()
        {
            var jsonString = await new WebClientService().GetString(URIConstant.RestUrl);
            var data = JsonConvert.DeserializeObject<List<DataContent>>(jsonString);
            return data;
            //throw new NotImplementedException();
        }

        public Task<DataContent> GetData(int id)
        {
            throw new NotImplementedException();
        }
    }
}
