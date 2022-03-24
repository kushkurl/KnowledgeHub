using KnowledgeApp.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeApp.Services
{
    public interface IRestService
    {

        //Task<List<DataContent>> GetAllData();
        Task<List<DataContent>> GetData();
        Task<DataContent> GetData(int id);

        Task<DataContent> Delete(DataContent data);

        Task<DataContent> Update(DataContent data);

        Task<DataContent> Add(DataContent data);

    }
}
