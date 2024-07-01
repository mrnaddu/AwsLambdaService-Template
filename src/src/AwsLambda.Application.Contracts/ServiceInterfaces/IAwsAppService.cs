namespace AwsLambda.Application.ServiceInterfaces;

public interface IAwsAppService
{
    string GetRdsDatabaseConnectionString();
    string GetDocumentDatabaseConnectionString();
}
