namespace Basket.Api.Mappers;

public class BasketMapper : Profile
{
    protected BasketMapper()
    {
        CreateMap<ShoppingCart, ShoppingCartViewModel>();
        CreateMap<ShoppingCartItem, ShoppingCartItemViewModel>();

        CreateMap<ShoppingCartInputModel, ShoppingCart>();
        CreateMap<ShoppingCartItemInputModel, ShoppingCartItem>();
    }
}
