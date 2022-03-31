using KnowledgeApp.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeApp.Services
{
    public interface IRestService
    {

        //Task<List<DataContent>> GetAllData();
        Task<List<Category>> GetCategory();
        Task<List<DataContent>> GetData(int cId);
        Task<DataContent> GetData(int cId, int DataObj);

        Task<DataContent> Delete(int cId, DataContent data);

        Task<DataContent> Update(int cId, DataContent data);

        Task<DataContent> Add(int cId, DataContent data);

    }
}
