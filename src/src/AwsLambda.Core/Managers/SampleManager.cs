using AwsLambda.Core.Entities;
using AwsLambda.Core.RepositoryInterfaces;

namespace AwsLambda.Core.Managers;

public class SampleManager
{
    private readonly ISampleRepository sampleRepository;
    public SampleManager(ISampleRepository sampleRepository)
    {
        this.sampleRepository = sampleRepository;
    }

    public async Task<Sample> CreateAsync(Sample sample)
    {
        var exists = await sampleRepository.GetByNameAsync(sample.Name);
        if (exists != null)
        {
            throw new Exception("Sample already exists");
        }
        return new Sample(sample.Id, sample.Name, sample.Age, sample.Email);
    }
}
