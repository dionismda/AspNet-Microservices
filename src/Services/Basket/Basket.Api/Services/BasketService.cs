namespace Basket.Api.Services;

public class BasketService : IBasketService
{
    private readonly IBasketRepository _repository;
    private readonly DiscountGrpcService _discountGrpcService;

    public BasketService(IBasketRepository repository, DiscountGrpcService discountGrpcService)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _discountGrpcService = discountGrpcService;
    }

    public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
    {
        foreach (var item in basket.Items)
        {
            var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
            item.Price -= coupon.Amount;
        }

        return await _repository.UpdateBasket(basket);
    }
}
