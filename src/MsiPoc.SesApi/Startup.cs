using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(MsiPoc.SesApi.Startup))]
namespace MsiPoc.SesApi
{
    public sealed class Startup: FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<DpsConfiguration>()
                .Configure<IConfiguration>((dpsConfiguration, configuration) => configuration.GetSection("Dps:Api").Bind(dpsConfiguration));
        }
    }
}