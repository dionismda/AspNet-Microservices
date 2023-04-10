namespace Discount.Api.Mappers;

public class DiscountMapper : Profile
{
    public DiscountMapper()
    {
        CreateMap<CouponInputModel, Coupon>();
        CreateMap<Coupon, CouponViewModel>();
        CreateMap<CouponInputModel, CouponViewModel>();
    }
}
