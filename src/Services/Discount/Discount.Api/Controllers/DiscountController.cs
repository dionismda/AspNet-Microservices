namespace Discount.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public sealed class DiscountController : ControllerBase
{
    private readonly IDiscountRepository _repository;
    private readonly IMapper _mapper;

    public DiscountController(IDiscountRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet("{productName}", Name = "GetDiscount")]
    [ProducesResponseType(typeof(CouponViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CouponViewModel>> GetDiscount(string productName)
    {
        var discount = await _repository.GetDiscount(productName);
        return Ok(_mapper.Map< CouponViewModel>(discount));
    }

    [HttpPost]
    [ProducesResponseType(typeof(CouponViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CouponViewModel>> CreateDiscount([FromBody] CouponInputModel coupon)
    {
        await _repository.CreateDiscount(_mapper.Map<Coupon>(coupon));
        return CreatedAtRoute("GetDiscount", new { productName = coupon.ProductName }, _mapper.Map<CouponViewModel>(coupon));
    }

    [HttpPut]
    [ProducesResponseType(typeof(CouponViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CouponViewModel>> UpdateBasket([FromBody] CouponInputModel coupon)
    {
        return Ok(await _repository.UpdateDiscount(_mapper.Map<Coupon>(coupon)));
    }

    [HttpDelete("{productName}", Name = "DeleteDiscount")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> DeleteDiscount(string productName)
    {
        return Ok(await _repository.DeleteDiscount(productName));
    }
}
