using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net;
using MsiPoc.Abstractions;

namespace MsiPoc.DpsApi
{
    public static class RedirectDeviceFunction
    {
        [FunctionName("RedirectDeviceFunction")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "devices/{id}/redirect/{env}")]
            HttpRequest req,
            [FromRoute]
            string id,
            [FromRoute]
            string env,
            ILogger log)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(env))
            {
                return new BadRequestObjectResult("Id and Env are mandatory");
            }

            var device = Database.Devices.FirstOrDefault(d => d.Id == id);
            if (device == null)
            {
                return new NotFoundObjectResult($"No device with id {id}");
            }

            var environment = Database.Environments.FirstOrDefault(e => e.Name == env);
            if (environment == null)
            {
                return new NotFoundObjectResult($"No environment with name {env}");
            }

            device.Redirection = new Redirection
            {
                Code = HttpStatusCode.Redirect,
                Endpoint = environment.Uri
            };

            return new OkObjectResult(device);
        }
    }
}
