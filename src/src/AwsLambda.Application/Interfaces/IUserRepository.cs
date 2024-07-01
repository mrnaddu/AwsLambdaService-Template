using MongoDB.Bson;

namespace AwsLambda.Application.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<BsonDocument>> GetAllUsers();
}
