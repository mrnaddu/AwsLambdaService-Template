using AwsLambda.Application.Contracts.ServiceInterfaces;
using AwsLambda.Core.RepositoryInterfaces;
using MongoDB.Bson;

namespace AwsLambda.Application.Services;

public class UserAppService : IUserAppService
{
    private readonly IUserRepository userRepository;
    public UserAppService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<IEnumerable<BsonDocument>> GetAllAsync()
    {
        return await userRepository.GetAllUsersAsync();
    }
}
