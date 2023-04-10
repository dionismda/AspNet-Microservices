namespace Discount.Shared.Interfaces;

public interface IConnectionDapper
{
    Task<IDbConnection> GetConnectionAsync();
}
