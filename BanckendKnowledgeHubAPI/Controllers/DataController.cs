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
    [Route("api/Data")]
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
        public async Task<ActionResult<List<DataContent>>> Get()
        {
            return await _dataOperation.Get();
            //return dataContent.GetAll();
            //return "working fine";
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DataContent>> Get(int id)
        {
            var data = await _dataOperation.Get(id);
            if (data == null)
                return BadRequest("Record Not found");
            else
                return data;
        }

        [HttpPost]
        public async Task<ActionResult> Insert(DataContent data)
        {
            await _dataOperation.Insert(data);
            return Ok(data);
        }
    }
}
