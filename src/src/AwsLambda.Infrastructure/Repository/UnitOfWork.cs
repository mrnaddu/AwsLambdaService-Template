using AwsLambda.Core.Interfaces;

namespace AwsLambda.Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(ISampleRepository sampleRepository)
    {
        Sample = sampleRepository;
    }
    public ISampleRepository Sample { get; }
}
