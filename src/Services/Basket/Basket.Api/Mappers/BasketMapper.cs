namespace Basket.Api.Mappers;

public class BasketMapper : Profile
{
    public BasketMapper()
    {
        CreateMap<ShoppingCart, ShoppingCartViewModel>();
        CreateMap<ShoppingCartItem, ShoppingCartItemViewModel>();

        CreateMap<ShoppingCartInputModel, ShoppingCart>();
        CreateMap<ShoppingCartItemInputModel, ShoppingCartItem>();
    }
}
