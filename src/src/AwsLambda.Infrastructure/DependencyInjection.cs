﻿using AwsLambda.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AwsLambda.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<ISampleRepository, SampleRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IAwsAppService, AwsHelper>();
        services.AddTransient<IUserRepository, UserRepository>();
    }
}
