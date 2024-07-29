using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Diagnostics;

using Stryker.BC.API;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stryker.BC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        // GET: api/<LogController>
        [HttpGet]
        public IEnumerable<Models.Log> Get()
        {
            var val1 = new Models.Log { LogId = 32, LogDate = DateTime.Now.AddSeconds(-3), LogMessage = "Component failed successfully.", LogType = 1 };
            var val2 = new Models.Log { LogId = 33, LogDate = DateTime.Now, LogMessage = "Component successfully failed.", LogType = 2 };
            var val3 = new Models.Log { LogId = 34, LogDate = DateTime.Now.AddSeconds(+3), LogMessage = "Failure isn't an option.", LogType = 2 };

            return new Models.Log[] { val1, val2, val3 };
        }

        // GET api/<LogController>/5
        [HttpGet("{id}")]
        public Models.Log Get(int id)
        {
            var val1 = new Models.Log { LogId = id, LogDate = DateTime.Now.AddSeconds(-3), LogMessage = "Access was prohibited due to error.", LogType = 1 };
            return val1;
        }

        // POST api/<LogController>
        [HttpPost]
        public void Post([FromBody] Models.Log log)
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
