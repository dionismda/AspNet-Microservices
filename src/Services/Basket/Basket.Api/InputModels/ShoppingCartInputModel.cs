namespace Basket.Api.InputModels;

public sealed class ShoppingCartInputModel
{
    public string UserName { get; set; }
    public List<ShoppingCartItemInputModel> Items { get; set; } = new List<ShoppingCartItemInputModel>();
}
