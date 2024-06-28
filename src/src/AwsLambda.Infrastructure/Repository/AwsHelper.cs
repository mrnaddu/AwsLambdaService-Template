using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using AwsLambda.Application.Interfaces;
using AwsLambda.Core.Const;
using Newtonsoft.Json.Linq;

namespace AwsLambda.Infrastructure.Repository;

public class AwsHelper : IAwsHelper
{
    public string GetRdsDatabaseConnectionString()
    {
        using var secretsManagerClient = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(AwsConst.Region));
        var request = new GetSecretValueRequest
        {
            SecretId = AwsConst.RdsSecretName,
            VersionStage = AwsConst.Version,
        };
        try
        {
            var response = secretsManagerClient.GetSecretValueAsync(request).Result;
            var secret = response.SecretString;
            var secretObject = JObject.Parse(secret);

            var rdsProxyHost = secretObject["rds_proxy_host"].ToString();
            var userName = secretObject["user_name"].ToString();
            var port = secretObject["port"].ToString();
            var password = secretObject["password"].ToString();
            var complianceDatabase = secretObject["compliance_database"].ToString();

            var connectionString = $"Server={rdsProxyHost};Port={port};Database={complianceDatabase};Uid={userName};Pwd={password};Connect Timeout=5";

            return connectionString;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
