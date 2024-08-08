using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Diagnostics;
using Asp.Versioning;
using Stryker.BC.API.v1_1;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stryker.BC.API.v1_1.Controllers
{
    [ApiVersion("1.1", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        // GET: api/v1/<LogController>
        [HttpGet]
        public IEnumerable<Models.LogModel> Get()
        {
            var val1 = new Models.LogModel { LogId = 32, LogDate = DateTime.Now.AddSeconds(-3), LogMessage = "Component failed successfully.", LogType = 1 };
            var val2 = new Models.LogModel { LogId = 33, LogDate = DateTime.Now, LogMessage = "Component successfully failed.", LogType = 2 };
            var val3 = new Models.LogModel { LogId = 34, LogDate = DateTime.Now.AddSeconds(+3), LogMessage = "Failure isn't an option.", LogType = 2 };

            return new Models.LogModel[] { val1, val2, val3 };
        }

        // GET api/v1/<LogController>/5
        [HttpGet("{id}")]
        public Models.LogModel Get(int id)
        {
            var val1 = new Models.LogModel { LogId = id, LogDate = DateTime.Now.AddSeconds(-3), LogMessage = "Access was prohibited due to error.", LogType = 1 };
            return val1;
        }

        // POST api/v1/<LogController>
        [HttpPost]
        public void Post([FromBody] Models.LogModel log)
        {
            Debug.WriteLine(log.ToJson(Newtonsoft.Json.Formatting.Indented));
        }

        // PUT api/v1/<LogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/v1/<LogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
