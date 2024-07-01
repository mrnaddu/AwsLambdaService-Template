using Amazon.Lambda.Annotations;
using Amazon.Lambda.Core;
using AwsLambda.Application.Contracts.Dtos;
using AwsLambda.Application.Contracts.ServiceInterfaces;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AwsLambda.Lambda;

public class Functions
{
    private readonly ISampleAppService sampleAppService;

    public Functions(ISampleAppService sampleAppService)
    {
        this.sampleAppService = sampleAppService;
    }

    // RdsMysql
    [LambdaFunction]
    public async Task<SampleDto> GetSampleAsyncHandler(string id, ILambdaContext context)
    {
        if (string.IsNullOrEmpty(id))
        {
            context.Logger.LogDebug($"Did NOT receive the valid request for sample.");
            return null;
        }
        return await sampleAppService.GetSampleAsync(int.Parse(id));
    }

    [LambdaFunction]
    public async Task<SampleDto> CreateSampleAsyncHandler(CreateUpdateSampleDto input, ILambdaContext context)
    {
        context.Logger.LogDebug($"Received the request with Sample to create new.");
        return await sampleAppService.CreateSampleAsync(input);
    }
}

