using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Diagnostics;

using Stryker.BC.API;
using Stryker.BC.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stryker.BC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        // GET: api/<LogController>
        [HttpGet]
        public IEnumerable<LogModel> Get()
        {
            var val1 = new LogModel { LogId = 32, LogDate = DateTime.Now.AddSeconds(-3), LogMessage = "Component failed successfully.", LogType = 1 };
            var val2 = new LogModel { LogId = 33, LogDate = DateTime.Now, LogMessage = "Component successfully failed.", LogType = 2 };
            var val3 = new LogModel { LogId = 34, LogDate = DateTime.Now.AddSeconds(+3), LogMessage = "Failure isn't an option.", LogType = 2 };

            return new LogModel[] { val1, val2, val3 };
        }

        // GET api/<LogController>/5
        [HttpGet("{id}")]
        public LogModel Get(int id)
        {
            var val1 = new LogModel { LogId = id, LogDate = DateTime.Now.AddSeconds(-3), LogMessage = "Access was prohibited due to error.", LogType = 1 };
            return val1;
        }

        // POST api/<LogController>
        [HttpPost]
        public void Post([FromBody] LogModel log)
        {
            Debug.WriteLine(log.ToJson(Newtonsoft.Json.Formatting.Indented));
        }

        // PUT api/<LogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
