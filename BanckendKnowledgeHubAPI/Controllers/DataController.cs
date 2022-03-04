using KnowledgeHub.Data.Interfaces;
using KnowledgeHub.Data.Models;
using KnowledgeHub.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BanckendKnowledgeHubAPI.Controllers
{
    [ApiController]
    [Route("api/Data")]
    public class DataController : ControllerBase
    {
        private IDataOperation dataContent = new DataOperation();

        private readonly DataStoreContext _context;

        public DataController(DataStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DataContent>>> Get()
        {
            return await _context.DataContent.ToListAsync();
            //return dataContent.GetAll();
            //return "working fine";
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DataContent>> Get(int id)
        {
            var data = await _context.DataContent.FindAsync(id);
            if (data == null)
                return BadRequest("Record Not found");
            else
                return data;
        }

        [HttpPost]
        public async Task<ActionResult> Insert(DataContent data)
        {
            _context.DataContent.Add(data);
            await _context.SaveChangesAsync();
            return Ok(data);
        }
    }
}
