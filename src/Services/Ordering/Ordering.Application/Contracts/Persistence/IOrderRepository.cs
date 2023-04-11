namespace Ordering.Application.Contracts.Persistence;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
}
