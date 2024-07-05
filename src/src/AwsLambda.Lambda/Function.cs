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

    // RdsDb MysqlDb
    [LambdaFunction]
    public async Task<SampleDto> GetSampleAsyncHandler(int id, ILambdaContext context)
    {
        context.Logger.LogDebug($"Received the request with Sample finding by Id: {id}");
        return await sampleAppService.GetSampleAsync(id);
    }

    [LambdaFunction]
    public async Task<SampleDto> CreateSampleAsyncHandler(CreateUpdateSampleDto input, ILambdaContext context)
    {
        context.Logger.LogDebug($"Received the request with Sample to create new one: {input}");
        return await sampleAppService.CreateSampleAsync(input);
    }

    // DocDb DynamoDb
    [LambdaFunction]
    public async Task<SampleDto> CreateSampleAsyncHandler(CreateUpdateSampleDto input, ILambdaContext context)
    {
        context.Logger.LogDebug($"Received the request with Sample to create new one: {input}");
        return await sampleAppService.CreateSampleAsync(input);
    }
}

