using MongoDB.Bson;

namespace AwsLambda.Core.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<BsonDocument>> GetAllUsers();
}
