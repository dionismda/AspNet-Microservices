namespace Ordering.Api.Mappers;

public class OrderingMapper : Profile
{
    public OrderingMapper()
    {
        CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap();
    }
}
