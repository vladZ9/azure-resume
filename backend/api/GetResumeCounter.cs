using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data.Common;
using System.Configuration;
using System.Net.Http;
using System.Net;
using System.Text;

// this is a test comment
namespace Company.Function
{
    //this is another test comment
    public static class GetResumeCounter
    {
        [FunctionName("GetResumeCounter")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"AzureResume", collectionName: "Counter", ConnectionStringSetting ="AzureResumeConnectionString", Id="1", PartitionKey ="1")] Counter counter,
            [CosmosDB(databaseName:"AzureResume", collectionName: "Counter", ConnectionStringSetting ="AzureResumeConnectionString", Id="1", PartitionKey ="1")] out Counter updatedCounter,
            ILogger log)
        {
            // Here is where the counter gets updated
            log.LogInformation("C# HTTP trigger function processed a request.");
updatedCounter = counter;
updatedCounter.Count += 1;
var jsonToReturn = JsonConvert.SerializeObject(counter);
return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
{
    Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
};
            
        }
    }
}
