namespace Discount.Api.Interfaces;

public interface IConnectionDapper
{
    Task<IDbConnection> GetConnectionAsync();
}
