using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AcrUnleashed
{
    public static class WebHookReceiver
    {
        
        [FunctionName("WebHookReceiver")]
        
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "acr")] HttpRequest req,
            [Blob("events/{rand-guid}.json", FileAccess.Write, Connection = "StorageAccount")] Stream acrEvent,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            using (StreamWriter writer = new StreamWriter(acrEvent)){
                await writer.WriteAsync(requestBody);
            }
            return new OkResult();
        }
    }
}
