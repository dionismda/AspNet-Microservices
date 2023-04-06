namespace Discount.Api.Connections;

public sealed class NpgsqlDapperConnection : IConnectionDapper
{
    private readonly IConfiguration _configuration;

    public NpgsqlDapperConnection(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<IDbConnection> GetConnectionAsync()
    {
        var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

        await connection.OpenAsync();

        return connection;
    }
}
