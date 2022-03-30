using KnowledgeHub.Data.Interfaces;
using KnowledgeHub.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BanckendKnowledgeHubAPI.Controllers
{
    [ApiController]
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly IDataOperation _dataOperation;

        public CategoryController(IDataOperation dataOperation)
        {
            _dataOperation = dataOperation;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //var resp = new DataContent { id = 1, Title = "Test", Description = "testing desc" };
            return await _dataOperation.GetCategories();
            //return dataContent.GetAll();
            //return "working fine";
        }
    }
}
