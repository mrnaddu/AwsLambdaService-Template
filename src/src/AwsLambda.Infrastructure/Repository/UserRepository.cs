using AwsLambda.Application.Interfaces;
using AwsLambda.Core.Shared.Const;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AwsLambda.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly IAwsHelper awsHelper;
    public UserRepository(IAwsHelper awsHelper)
    {
        this.awsHelper = awsHelper;
    }

    public async Task<IEnumerable<BsonDocument>> GetAllUsers()
    {
        var mongoClient = new MongoClient(awsHelper.GetDocumentDatabaseConnectionString());
        var collection = mongoClient.GetDatabase(DocumentDbConst.DocumentCollection).GetCollection<BsonDocument>(DocumentDbConst.UsersDbTable);
        var filter = Builders<BsonDocument>.Filter.Empty;
        var documents = await collection.Find(filter).ToListAsync();
        return documents;
    }
}
