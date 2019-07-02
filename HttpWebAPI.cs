using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Linq;

namespace Snoopy.Function
{
    public class HttpWebAPI
    {
        private readonly HttpClient _client;
        private readonly SchoolDbContext _context;

        public HttpWebAPI(IHttpClientFactory httpClientFactory, 
            SchoolDbContext context) {
            _client = httpClientFactory.CreateClient();
            _context = context;
        }

        [FunctionName("HttpWebAPI")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }

        [FunctionName("GetStudents")]
        public IActionResult GetStudents(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "students")] HttpRequest req,
            ILogger log) 
        {
            log.LogInformation("C# HTTP GET/posts trigger function processed a request.");

            var studentsArray = _context.Students.OrderBy(s => s.School).ToArray();

            return new OkObjectResult(studentsArray);
        }        
    }
}
