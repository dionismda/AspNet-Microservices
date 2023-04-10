namespace Discount.Grpc.Mappers;

public class Discount : Profile
{
    public Discount()
    {
        CreateMap<Coupon, CouponModel>()
            .ReverseMap();
    }
}
