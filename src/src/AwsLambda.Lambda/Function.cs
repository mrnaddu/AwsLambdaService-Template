using Amazon.Lambda.Annotations;
using Amazon.Lambda.Core;
using AwsLambda.Application.Interfaces;
using AwsLambda.Core.Dtos;
using AwsLambda.Core.Entities;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AwsLambda.Lambda;

public class Functions
{
    private readonly ISampleRepository sampleRepository;
    public Functions(ISampleRepository sampleRepository)
    {
        this.sampleRepository = sampleRepository;
    }

    [LambdaFunction]
    public async Task<SampleResponseDto> GetSampleAsyncHandler(string id, ILambdaContext context)
    {
        SampleResponseDto sampleResponseDto = new();

        if (string.IsNullOrEmpty(id))
        {
            context.Logger.LogDebug($"Did NOT receive the valid request for sample.");

            sampleResponseDto.Message = "Received Invalid Sample Id";

            return sampleResponseDto;
        }

        context.Logger.LogDebug($"Received the request with Sample Id {id}.");
        Sample sample = await sampleRepository.GetByIdAsync(int.Parse(id));

        context.Logger.LogDebug($"Sending the response for Sample Id {id}.");
        sampleResponseDto = Mapper.GenerateSampleResponseDto(sample);
        return sampleResponseDto;
    }

    [LambdaFunction]
    public async Task<int> CreateSampleAsyncHandler(Sample entity, ILambdaContext context)
    {
        context.Logger.LogDebug($"Received the request with Sample Id {entity.Id} to create new.");

        int rows = await sampleRepository.AddAsync(entity);

        context.Logger.LogDebug($"Sending the response for New Sample Id {entity.Id}.");
        context.Logger.LogDebug($"inserted the new Sample and effected rows {rows}.");
        return rows;
    }

    [LambdaFunction]
    public async Task<IEnumerable<Sample>> GetAllSampleHandler(ILambdaContext context)
    {
        context.Logger.LogDebug($"Received the request for Get All Sample.");

        var samplesList = await sampleRepository.GetAllAsync();
        return samplesList;
    }

    [LambdaFunction]
    public async Task<int> UpdateSampleHandler(Sample entity, ILambdaContext context)
    {
        context.Logger.LogDebug($"Received the request with Sample Id {entity.Id} to update.");

        int rows = await sampleRepository.UpdateAsync(entity);

        context.Logger.LogDebug($"Sending the response for New Sample Id {entity.Id}.");
        context.Logger.LogDebug($"updated the Sample and effected rows {rows}.");
        return rows;
    }
}

