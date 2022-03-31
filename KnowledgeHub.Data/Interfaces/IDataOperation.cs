using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHub.Data.Models;

namespace KnowledgeHub.Data.Interfaces
{
    public interface IDataOperation
    {
        bool DoesItemExist(int id);
        Task<List<DataContent>> Get(int cId);
        Task<List<Category>> GetCategories();
        Task<DataContent> Get(int cId, int id);
        Task<DataContent> Insert(DataContent item);
        Task<DataContent> Update(DataContent item);
        void Delete(int id);
    }
}
