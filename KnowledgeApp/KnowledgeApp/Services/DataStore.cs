using KnowledgeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeApp.Services
{
    public class DataStore : IDataStore<DataContent>
    {
        public Task DeleteTodoItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DataContent>> RefreshDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveTodoItemAsync(DataContent item, bool isNewItem)
        {
            throw new NotImplementedException();
        }
    }
}