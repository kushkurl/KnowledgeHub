using KnowledgeHub.Data.Interfaces;
using KnowledgeHub.Data.Models;
using Microsoft.EntityFrameworkCore;
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
        private readonly DataStoreContext _context;

        public async Task<List<DataContent>> Get()
        {
            var data = new List<DataContent>{ new DataContent{ id = 1, Title = "Test", Description = "testing desc" },
                new DataContent{ id = 1, Title = "Test", Description = "testing desc" } };
            return data;//await _context.DataContent.ToListAsync();
        }

        public DataOperation(DataStoreContext context)
        {
            _context = context;
            InitializeData();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool DoesItemExist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DataContent> Get(int id)
        {
            //var data = await _context.DataContent.FindAsync(id);
            return null;
        }

        public async Task<DataContent> Insert(DataContent item)
        {
            _context.DataContent.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<DataContent> Update(DataContent item)
        {
            var data = await _context.DataContent.FindAsync(item.id);
            data.Title = item.Title;
            _context.DataContent.Update(data);
            await _context.SaveChangesAsync();
            return data;
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
    }
}
