using KnowledgeApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeApp.Services
{
    public interface IDataStore<T>
    {
        Task<List<DataContent>> RefreshDataAsync();

        Task SaveTodoItemAsync(DataContent item, bool isNewItem);

        Task DeleteTodoItemAsync(string id);
    }
}
