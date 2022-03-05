using KnowledgeApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeApp.Services
{
    public class DataManager
    {
		IDataStoreService restService;

		public DataManager(IDataStoreService service)
		{
			restService = service;
		}

		public Task<List<DataContent>> GetTasksAsync()
		{
			return restService.RefreshDataAsync();
		}

		public Task SaveTaskAsync(DataContent item, bool isNewItem = false)
		{
			return restService.SaveTodoItemAsync(item, isNewItem);
		}

		public Task DeleteTaskAsync(DataContent item)
		{
			return restService.DeleteTodoItemAsync(item.id);
		}
	}
}
