namespace AwsLambda.Application.Interfaces;

public interface IUnitOfWork
{
    ISampleRepository Sample { get; }
}
