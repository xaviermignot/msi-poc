using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace MsiPoc.DpsApi
{
    public static class DeleteRedirectionFunction
    {
        [FunctionName("DeleteRedirectionFunction")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "devices/{id}/redirect")]
            HttpRequest req,
            [FromRoute]
            string id,
            ILogger log)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new BadRequestObjectResult("Id and Env are mandatory");
            }

            var device = Database.Devices.FirstOrDefault(d => d.Id == id);
            if (device == null)
            {
                return new NotFoundObjectResult($"No device with id {id}");
            }

            device.Redirection = null;

            return new OkObjectResult(device);
        }
    }
}
