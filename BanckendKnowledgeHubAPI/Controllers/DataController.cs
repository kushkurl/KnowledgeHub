using KnowledgeHub.Data.Interfaces;
using KnowledgeHub.Data.Models;
using KnowledgeHub.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BanckendKnowledgeHubAPI.Controllers
{
    [ApiController]
    [Route("api/{categoryId:int}/Data")]
    public class DataController : ControllerBase
    {
        //IDataOperation _dataOperation = DependencyService.Get<IDataOperation>();
        //private IDataOperation dataContent = new IDataOperation();

        private readonly IDataOperation _dataOperation;

        public DataController(IDataOperation dataOperation)
        {
            _dataOperation = dataOperation;
        }
        [HttpGet]
        public async Task<ActionResult<List<DataContent>>> Get(int categoryId)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //var resp = new DataContent { id = 1, Title = "Test", Description = "testing desc" };
            return await _dataOperation.Get(categoryId);
            //return dataContent.GetAll();
            //return "working fine";
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DataContent>> Get(int categoryId, int id)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            var data = await _dataOperation.Get(categoryId, id);
            if (data == null)
                return BadRequest("Record Not found");
            else
                return data;
        }

        [HttpPost]
        public async Task<ActionResult> Insert(DataContent data)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            await _dataOperation.Insert(data);
            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(DataContent data, int id)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            await _dataOperation.Update(data);
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            _dataOperation.Delete(id);
            return Ok();
        }

    }
}
