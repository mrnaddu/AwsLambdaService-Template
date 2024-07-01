namespace AwsLambda.Application.Interfaces;

public interface IAwsHelper
{
    string GetRdsDatabaseConnectionString();
    string GetDocumentDatabaseConnectionString();
}
