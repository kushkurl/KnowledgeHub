using KnowledgeApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeApp.Services
{
    public interface IDataStoreService
    {
        Task<List<DataContent>> RefreshDataAsync();

        Task SaveTodoItemAsync(DataContent item, bool isNewItem);

        Task DeleteTodoItemAsync(int id);
    }
}
