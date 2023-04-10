namespace Basket.Api.Interfaces;

public interface IBasketService
{
    Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
}
