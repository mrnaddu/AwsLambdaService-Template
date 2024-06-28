using AwsLambda.Application.Interfaces;
using AwsLambda.Core.Entities;
using Dapper;
using MySql.Data.MySqlClient;

namespace AwsLambda.Infrastructure.Repository;

public class SampleRepository : ISampleRepository
{
    private readonly IAwsHelper awsHelper;
    public SampleRepository(IAwsHelper awsHelper)
    {
        this.awsHelper = awsHelper;
    }
    public async Task<int> AddAsync(Sample entity)
    {
        var sql = "INSERT INTO t_sample (id, name, age, email) VALUES (@Id,@Name, @Age, @Email)";
        using var connection = new MySqlConnection(awsHelper.GetRdsDatabaseConnectionString());
        connection.Open();
        var result = await connection.ExecuteAsync(sql, entity);
        return result;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var sql = "DELETE FROM t_sample WHERE id = @id";
        using var connection = new MySqlConnection(awsHelper.GetRdsDatabaseConnectionString());
        connection.Open();
        var result = await connection.ExecuteAsync(sql, new { Id = id });
        return result;
    }

    public async Task<IEnumerable<Sample>> GetAllAsync()
    {
        var sql = "SELECT * FROM t_sample";
        using var connection = new MySqlConnection(awsHelper.GetRdsDatabaseConnectionString());
        connection.Open();
        var result = await connection.QueryAsync<Sample>(sql);
        return result.ToList();
    }

    public async Task<Sample> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM t_sample WHERE id = @id";
        using var connection = new MySqlConnection(awsHelper.GetRdsDatabaseConnectionString());
        connection.Open();
        var result = await connection.QuerySingleOrDefaultAsync<Sample>(sql, new { Id = id });
        return result;
    }

    public async Task<int> UpdateAsync(Sample entity)
    {
        var sql = "UPDATE t_sample SET name = @Name, age = @Age, email = @Email, WHERE id = @Id";
        using var connection = new MySqlConnection(awsHelper.GetRdsDatabaseConnectionString());
        connection.Open();
        var result = await connection.ExecuteAsync(sql, entity);
        return result;
    }
}
