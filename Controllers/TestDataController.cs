using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoDBATLAS.Controllers
{
    [Route("api/[controller]")]
    public class TestDataController : Controller
    {
        private readonly MongoDBService _mongoDBService;

        public TestDataController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<List<TestData>> Get()
        {
            return await _mongoDBService.Get();
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TestData value)
        {
            await _mongoDBService.Insert(value);
            return CreatedAtAction(nameof(Get), new {Id = value.Id}, value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

