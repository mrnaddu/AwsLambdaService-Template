using MongoDB.Bson;

namespace AwsLambda.Application.Contracts.ServiceInterfaces;

public interface IUserAppService
{
    Task<IEnumerable<BsonDocument>> GetAllAsync();
}
