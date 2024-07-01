namespace AwsLambda.Core.Interfaces;

public interface IUnitOfWork
{
    ISampleRepository Sample { get; }
}
