using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net;

namespace MsiPoc.DpsApi
{
    public static class GetDeviceFunction
    {
        [FunctionName("GetDeviceFunction")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "devices/{id}")]
            HttpRequest req,
            [FromRoute]
            string id,
            ILogger log)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new BadRequestObjectResult("Id is mandatory");
            }

            var device = Database.Devices.FirstOrDefault(d => d.Id == id);
            if (device == null)
            {
                return new NotFoundObjectResult($"No device with id {id}");
            }

            if (device.Redirection?.Code == HttpStatusCode.Redirect)
            {
                return new RedirectResult(device.Redirection.Endpoint.AbsoluteUri);
            }

            return new OkObjectResult(device);
        }
    }
}
