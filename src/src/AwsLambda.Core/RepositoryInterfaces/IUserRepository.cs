using MongoDB.Bson;

namespace AwsLambda.Core.RepositoryInterfaces;

public interface IUserRepository
{
    Task<IEnumerable<BsonDocument>> GetAllUsersAsync();
    Task<BsonDocument> GetUserEmailAsync(string name);
}
