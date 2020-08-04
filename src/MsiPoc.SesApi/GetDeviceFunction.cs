using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MsiPoc.Abstractions;

namespace MsiPoc.SesApi
{
    public class GetDeviceFunction
    {
        private readonly HttpClient _httpClient;
        private readonly DpsConfiguration _dpsConfiguration;

        public GetDeviceFunction(HttpClient httpClient, IOptions<DpsConfiguration> dpsConfiguration)
        {
            _httpClient = httpClient;
            _dpsConfiguration = dpsConfiguration.Value;
        }

        [FunctionName("GetDeviceFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "devices/{id}")]
            HttpRequest req,
            [FromRoute]
            string id,
            ILogger log)
        {
            var response = await _httpClient.GetAsync(new Uri(_dpsConfiguration.BaseUri, $"devices/{id}"));

            return response.StatusCode switch
            {
                HttpStatusCode.OK => new OkObjectResult(await response.Content.ReadAsAsync<Device>()),
                HttpStatusCode.NotFound => new NotFoundResult(),
                HttpStatusCode.RedirectKeepVerb => new RedirectResult(response.Headers.Location.ToString()),
                _ => throw new NotSupportedException()
            };
        }
    }
}
