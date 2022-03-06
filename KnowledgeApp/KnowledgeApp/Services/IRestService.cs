using KnowledgeApp.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeApp.Services
{
    public interface IRestService
    {
        Task<List<DataContent>> GetData();
        Task<DataContent> GetData(int id);

    }
}
