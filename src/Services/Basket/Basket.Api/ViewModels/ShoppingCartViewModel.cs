namespace Basket.Api.ViewModels;

public sealed class ShoppingCartViewModel
{
    public string UserName { get; set; }
    public List<ShoppingCartItemViewModel> Items { get; set; } = new List<ShoppingCartItemViewModel>();
}
