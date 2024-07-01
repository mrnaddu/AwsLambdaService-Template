using Amazon.Lambda.Annotations;
using AwsLambda.Application.Contracts.ServiceInterfaces;
using AwsLambda.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AwsLambda.Lambda;

[LambdaStartup]
public class DependencyInjection
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ISampleAppService, SampleAppService>();
    }
}
