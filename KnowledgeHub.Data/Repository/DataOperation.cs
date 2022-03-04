using KnowledgeHub.Data.Interfaces;
using KnowledgeHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHub.Data.Repository
{
    public class DataOperation : IDataOperation
    {
        private List<DataContent> _itemList;
        public List<DataContent> GetAll()
        {
            return _itemList;
        }

        public DataOperation()
        {
            InitializeData();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool DoesItemExist(int id)
        {
            return _itemList.Any(item => item.id == id);
        }

        public DataContent Get(int id)
        {
            return _itemList.FirstOrDefault(item => item.id == id);
        }

        public void Insert(DataContent item)
        {
            _itemList.Add(item);
        }

        public void Update(DataContent item)
        {
            var dataItem = this.Get(item.id);
            var index = _itemList.IndexOf(dataItem);
            _itemList.RemoveAt(index);
            _itemList.Insert(index, item);
        }
        private void InitializeData()
        {
            _itemList = new List<DataContent>();

            var Item1 = new DataContent
            {
                id = 1,
                Title = "Learn app development",
                Description = "Take Microsoft Learn Courses"
            };

            var Item2 = new DataContent
            {
                id = 2,
                Title = "Develop apps",
                Description = "Use Visual Studio and Visual Studio for Mac"
            };

            var Item3 = new DataContent
            {
                id = 3,
                Title = "Publish apps",
                Description = "All app stores"
            };

            _itemList.Add(Item1);
            _itemList.Add(Item2);
            _itemList.Add(Item3);
        }

        public List<DataContent> Get()
        {
            throw new NotImplementedException();
        }
    }
}
