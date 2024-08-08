using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Humanizer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;
using Mono.TextTemplating;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.CodeDom.Compiler;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Xml;
using System;

using Stryker.BC.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stryker.BC.API.Controllers.v1_0
{

    ///<Summary>
    /// Web API Controller for: Customer
    ///</Summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ///<Summary>
        /// GET for Customer
        ///</Summary>
        ///<returns>
        ///List of CustomerModel objects.  NOTE: null may be returned
        ///</returns>
        [HttpGet]
        public IEnumerable<CustomerModel> Get()
        {
            var cust1 = Get(1228);
            var cust2 = Get(1229);
            var cust3 = Get(1230);

            return new CustomerModel[] { cust1, cust2, cust3 };
        }

        // GET api/v1.0/<CustomerController>/5
        ///<returns>
        ///List of CustomerModel objects.  NOTE: null may be returned
        ///</returns>
        [Produces("application/json", "application/xml", Type = typeof(CustomerModel))]
        [HttpGet("{id}")]
        public CustomerModel Get(int id)
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


            JsonSerializerOptions opts = new JsonSerializerOptions();
            //opts.ToJson(Newtonsoft.Json.Formatting.Indented);
            //opts.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never;
            //opts.PropertyNameCaseInsensitive = true;
            //opts = new System.Text.Json.JsonSerializerOptions(System.Text.Json.JsonSerializerDefaults.Web);
            opts.IncludeFields = true;
            CustomerModel? obj = JsonSerializer.Deserialize<CustomerModel>(jsonString, opts);
            if (obj != null)
                obj.Customer_ID = id;     // Add variable data to my hardcoded json - for testing only
            return obj;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] CustomerModel Customer)
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
