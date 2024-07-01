using AwsLambda.Application.Interfaces;
using AwsLambda.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AwsLambda.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<ISampleRepository, SampleRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IAwsHelper, AwsHelper>();
        services.AddTransient<IUserRepository, UserRepository>();
    }
}
