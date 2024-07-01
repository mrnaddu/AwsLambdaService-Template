﻿using Amazon.Lambda.Annotations;
using AwsLambda.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AwsLambda.Lambda;

[LambdaStartup]
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ISampleRepository, SampleRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IAwsAppService, AwsHelper>();
        services.AddTransient<IUserRepository, UserRepository>();
    }
}
