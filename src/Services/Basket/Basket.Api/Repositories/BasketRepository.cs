namespace Basket.Api.Repositories;

public sealed class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache _redisCache;
    private JsonSerializerOptions _jsonSerializerOptions;

    public BasketRepository(IDistributedCache cache)
    {
        _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));

        _jsonSerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };
    }

    public async Task<ShoppingCart?> GetBasket(string userName)
    {
        var cacheBasket = await _redisCache.GetStringAsync(userName);

        if (String.IsNullOrEmpty(cacheBasket))
            return null;

        return JsonSerializer.Deserialize<ShoppingCart>(cacheBasket, _jsonSerializerOptions);
    }

    public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
    {
        await _redisCache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket, _jsonSerializerOptions));

        return await GetBasket(basket.UserName);
    }

    public async Task DeleteBasket(string userName)
    {
        await _redisCache.RemoveAsync(userName);
    }
}
