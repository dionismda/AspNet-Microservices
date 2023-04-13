namespace Basket.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public sealed class BasketController : ControllerBase
{
    private readonly IBasketRepository _repository;
    private readonly IMapper _mapper;
    private readonly IBasketService _service;
    private readonly IPublishEndpoint _publishEndpoint;

    public BasketController(IBasketRepository repository, IMapper mapper, IBasketService service, IPublishEndpoint publishEndpoint)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _service = service;
        _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
    }

    [HttpGet("{userName}", Name = "GetBasket")]
    [ProducesResponseType(typeof(ShoppingCartViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCartViewModel>> GetBasket(string userName)
    {
        var result = await _repository.GetBasket(userName);

        result ??= new ShoppingCart(userName);

        var basket = _mapper.Map<ShoppingCartViewModel>(result);

        return Ok(basket);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ShoppingCartViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCartViewModel>> UpdateBasket([FromBody] ShoppingCartInputModel basketInputModel)
    {
        var basket = _mapper.Map<ShoppingCart>(basketInputModel);

        var result = await _service.UpdateBasket(basket);

        return Ok(_mapper.Map<ShoppingCartViewModel>(result));
    }

    [HttpDelete("{userName}", Name = "DeleteBasket")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteBasket(string userName)
    {
        await _repository.DeleteBasket(userName);
        return Ok();
    }

    [Route("[action]")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Accepted)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
    {
        var basket = await _repository.GetBasket(basketCheckout.UserName);

        if (basket == null)
            return BadRequest();

        var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout);
        eventMessage.TotalPrice = basket.TotalPrice;
        await _publishEndpoint.Publish(eventMessage);

        await _repository.DeleteBasket(basket.UserName);

        return Accepted();
    }

}
