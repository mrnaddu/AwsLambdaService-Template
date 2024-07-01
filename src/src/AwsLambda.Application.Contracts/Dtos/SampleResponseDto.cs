using AwsLambda.Core.Entities;

namespace AwsLambda.Application.Contracts.Dtos;

public class SampleResponseDto
{
    public bool Success { get; set; }
    public string Message { get; set; } = "Record NOT Found";
    public Sample Sample { get; set; } = new Sample();
}
