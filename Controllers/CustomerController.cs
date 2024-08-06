using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Diagnostics;
using System.Text.Json;

using Stryker.BC.API;
using Humanizer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;
using Mono.TextTemplating;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Text.Json.Serialization.Metadata;
using System.Xml;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stryker.BC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Models.Customer> Get()
        {
            var cust1 = Get(1228);
            var cust2 = Get(1229);
            var cust3 = Get(1230);

            return new Models.Customer[] { cust1, cust2, cust3 };
        }

        // GET api/<CustomerController>/5
        [Produces("application/json", "application/xml", Type = typeof(Models.Customer))]
        [HttpGet("{id}")]
        public Models.Customer Get(int id)
        {
            // Result: System.Text.Json.JsonException = The JSON value could not be converted to Stryker.BC.API.Models.Customer.Path: $ | LineNumber: 1 | BytePositionInLine: 17.
            //string jsonString = @"
            //    [
            //      {
            //        ""Customer_ID"": 1228,
            //        ""Customer_Name"": ""James Hildeman (Live)"",
            //        ""First_Name"": ""James"",
            //        ""Last_Name"": ""Hildeman (Live)"",
            //        ""Company"": ""QOLOS"",
            //        ""Email"": ""jhildeman@live.com"",
            //        ""Phone"": ""999-999-9999"",
            //        ""Notes"": """",
            //        ""Store_Credit"": 0,
            //        ""Customer_Group"": ""QOLOS"",
            //        ""Orders"": 1,
            //        ""Date_Joined"": ""04/22/2024"",
            //        ""Addresses"": ""Address ID: 1777, Address Name: James Hildeman, Address First Name: James, Address Last Name: Hildeman, Address Company: Hilltech Studios LLC, Address Line 1: 19 West Ruby Blossum Trail, Address Line 2: Attn: Qolos/Styker, City/Suburb: Appleton, State/Province: Wisconsin, State Abbreviation: , Zip/Postcode: 54915, Country: United States, Building Type: commercial, Address Phone: 9204198099"",
            //        ""Receive_Marketing_Emails"": 0,
            //        ""Tax_Exempt_Category"": """"
            //      }
            //    ]
            //";

            // Result: 
            string jsonString = @"
                
                  {
                    ""Customer_ID"": 99,
                    ""Customer_Name"": ""James Hildeman (Live)"",
                    ""First_Name"": ""James"",
                    ""Last_Name"": ""Hildeman (Live)"",
                    ""Company"": ""QOLOS"",
                    ""Email"": ""jhildeman@live.com"",
                    ""Phone"": ""999-999-9999"",
                    ""Notes"": """",
                    ""Store_Credit"": 0,
                    ""Customer_Group"": ""QOLOS"",
                    ""Orders"": 1,
                    ""Date_Joined"": ""2020-09-06T11:31:01.923395-07:00"",
                    ""Addresses"": ""Address ID: 1777, Address Name: James Hildeman, Address First Name: James, Address Last Name: Hildeman, Address Company: Hilltech Studios LLC, Address Line 1: 19 West Ruby Blossum Trail, Address Line 2: Attn: Qolos/Styker, City/Suburb: Appleton, State/Province: Wisconsin, State Abbreviation: , Zip/Postcode: 54915, Country: United States, Building Type: commercial, Address Phone: 9204198099"",
                    ""Receive_Marketing_Emails"": false,
                    ""Tax_Exempt_Category"": """"
                  }  
            ";


            JsonSerializerOptions opts = new System.Text.Json.JsonSerializerOptions();
            //opts.ToJson(Newtonsoft.Json.Formatting.Indented);
            //opts.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never;
            //opts.PropertyNameCaseInsensitive = true;
            //opts = new System.Text.Json.JsonSerializerOptions(System.Text.Json.JsonSerializerDefaults.Web);
            opts.IncludeFields = true;
            Models.Customer? obj = JsonSerializer.Deserialize<Models.Customer>(jsonString, opts);
            obj.Customer_ID = id;     // Add variable data to my hardcoded json - for testing only
            // TODO: The Customer obj is being deserialized properly but the return sends nothing in Swagger!  Fix return issue.
            return obj;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Models.Customer Customer)
        {
            Debug.WriteLine(Customer.ToJson(Newtonsoft.Json.Formatting.Indented));
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
