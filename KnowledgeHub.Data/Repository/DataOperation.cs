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
        /*List<DataContent> data = new List<DataContent>{ new DataContent{ id = 1, Title = "Test", Description = "testing desc" },
                new DataContent{ id = 1, Title = "Test", Description = "testing desc" } };*/
        public DataOperation(DataStoreContext context)
        {
            _context = context;
            InitializeData();
        }

        public async Task<List<Category>> GetCategories()
        {

            return await _context.Categories.ToListAsync(); //_itemList;
        }
        public async Task<List<DataContent>> Get()
        {
            
            return await _context.DataContent.ToListAsync(); //_itemList;
        }

       
        public void Delete(int id)
        {
            _context.Remove(id);
            /*var data = _itemList.Find(x => x.id == id);
            _itemList.Remove(data);*/
            //throw new NotImplementedException();
        }

        public bool DoesItemExist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DataContent> Get(int id)
        {
            var data = await _context.DataContent.FindAsync(id);
            //var data = _itemList.Find(x => x.id == id);
            return data;
        }

        public async Task<DataContent> Insert(DataContent item)
        {
            _context.DataContent.Add(item);
            await _context.SaveChangesAsync();
            //_itemList.Add(item);
            return item;
        }

        public async Task<DataContent> Update(DataContent item)
        {
            var data = await _context.DataContent.FindAsync(item.id);
            data.Title = item.Title;
            data.Description = item.Description;
            data.CategoryId = item.CategoryId;
            data.file = item.file;
            _context.DataContent.Update(data);
            await _context.SaveChangesAsync();
            /*var data = _itemList.Find(x => x.id == item.id);
            data.Title = item.Title;
            data.Description = item.Description;*/
            return data;
        }

       

        public void Delete(DataContent item)
        {
            var resp = _context.Remove(item);
            _context.SaveChanges();
            //return resp;
        }
        private void InitializeData()
        {
            /* _itemList = new List<DataContent>();

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
             _itemList.Add(Item3);*/
        }
    }
}
