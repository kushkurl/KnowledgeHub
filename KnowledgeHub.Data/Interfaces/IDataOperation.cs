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
        List<DataContent> Get();
        DataContent Get(int id);
        void Insert(DataContent item);
        void Update(DataContent item);
        void Delete(int id);
    }
}
