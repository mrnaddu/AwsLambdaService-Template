namespace AwsLambda.Application.Services;

public interface IAwsAppService
{
    string GetRdsDatabaseConnectionString();
    string GetDocumentDatabaseConnectionString();
}
