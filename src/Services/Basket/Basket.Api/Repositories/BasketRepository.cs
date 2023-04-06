namespace Basket.Api.Repositories;

public class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache _redisCache;

    public BasketRepository(IDistributedCache cache)
    {
        _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public async Task<ShoppingCart> GetBasket(string userName)
    {
        var cacheBasket = await _redisCache.GetStringAsync(userName);

        if (String.IsNullOrEmpty(cacheBasket))
            throw new ArgumentNullException();

        return JsonSerializer.Deserialize<ShoppingCart>(cacheBasket);
    }

    public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
    {
        await _redisCache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket));

        return await GetBasket(basket.UserName);
    }

    public async Task DeleteBasket(string userName)
    {
        await _redisCache.RemoveAsync(userName);
    }
}
