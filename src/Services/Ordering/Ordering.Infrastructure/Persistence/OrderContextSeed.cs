namespace Ordering.Infrastructure.Persistence;

public class OrderContextSeed
{
    public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
    {
        if (!orderContext.Orders.Any())
        {
            orderContext.Orders.AddRange(GetPreconfiguredOrders());
            await orderContext.SaveChangesAsync();
            logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
        }
    }

    private static IEnumerable<Order> GetPreconfiguredOrders()
    {
        return new List<Order>
        {
                new Order()
                {
                    UserName = "Teste",
                    TotalPrice = 350,
                    FirstName = "Teste",
                    LastName = "Teste",
                    EmailAddress = "teste@gmail.com",
                    AddressLine = "teste",
                    Country = "teste",
                    State = "teste",
                    ZipCode = "13465000",
                    CardName = "teste",
                    CardNumber = "123456789",
                    Expiration = "10",
                    CVV = "123",
                    PaymentMethod = 2
                }
            };
    }
}