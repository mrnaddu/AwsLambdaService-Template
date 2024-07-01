using AwsLambda.Application.Services;
using AwsLambda.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AwsLambda.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IAwsAppService, AwsHelper>();
    }
}
