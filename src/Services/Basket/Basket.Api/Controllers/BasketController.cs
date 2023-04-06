namespace Basket.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public class BasketController : ControllerBase
{
    private readonly IBasketRepository _repository;
    private readonly IMapper _mapper;

    public BasketController(IBasketRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
    public async Task<ActionResult<ShoppingCartViewModel>> UpdateBasket([FromBody] ShoppingCartInputModel basket)
        => Ok(_mapper.Map<ShoppingCartViewModel>(await _repository.UpdateBasket(_mapper.Map<ShoppingCart>(basket))));

    [HttpDelete("{userName}", Name = "DeleteBasket")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteBasket(string userName)
    {
        await _repository.DeleteBasket(userName);
        return Ok();
    }

}
