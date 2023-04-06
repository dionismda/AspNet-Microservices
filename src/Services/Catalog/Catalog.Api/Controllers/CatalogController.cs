namespace Catalog.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public sealed class CatalogController : ControllerBase
{
    private readonly IProductRepository _repository;
    private readonly ILogger<CatalogController> _logger;
    private readonly IMapper _mapper;

    public CatalogController(IProductRepository repository, 
                             ILogger<CatalogController> logger,
                             IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProducts()
    {
        var products = await _repository.GetProducts();

        return Ok(_mapper.Map<IEnumerable<ProductViewModel>>(products));
    }

    [HttpGet("{id:length(24)}", Name = "GetProduct")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ProductViewModel>> GetProductById(string id)
    {
        var product = await _repository.GetProduct(id);

        if (product == null)
        {
            _logger.LogError($"Product with id: {id}, not found.");
            return NotFound();
        }

        return Ok(_mapper.Map<ProductViewModel>(product));
    }

    [Route("[action]/{category}", Name = "GetProductByCategory")]
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProductByCategory(string category)
    {
        var products = await _repository.GetProductByCategory(category);

        return Ok(_mapper.Map<IEnumerable<ProductViewModel>>(products));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ProductViewModel>> CreateProduct([FromBody] ProductInputModel productInputModel)
    {
        await _repository.CreateProduct(_mapper.Map<Product>(productInputModel));

        return CreatedAtRoute("GetProduct", new { id = productInputModel.Id }, _mapper.Map<ProductViewModel>(productInputModel));
    }

    [HttpPut]
    [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductInputModel productInputModel)
    {
        await _repository.UpdateProduct(_mapper.Map<Product>(productInputModel));

        return Ok(_mapper.Map<ProductViewModel>(productInputModel));
    }

    [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteProductById(string id)
    {
        return Ok(await _repository.DeleteProduct(id));
    }
}
