namespace Basket.Api.Entities;

public class ShoppingCart
{
    public string UserName { get; private set; }

    public List<ShoppingCartItem> _items;
    public IReadOnlyCollection<ShoppingCartItem> Items 
    { 
        get => _items.AsReadOnly(); 
        set => value.ToList(); 
    }

    public ShoppingCart()
    {
        _items = new List<ShoppingCartItem>();
    }

    public ShoppingCart(string userName) : this()
    {
        UserName = userName;
    }

    public void AddShoppingCartItem(ShoppingCartItem shoppingCartItem)
    {
        _items.Add(shoppingCartItem);
    }

    public void UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem)
    {
        if (shoppingCartItem.ProductId == default) return;

        var index = _items.FindIndex(x => x.ProductId == shoppingCartItem.ProductId);

        if (index != -1) _items[index] = shoppingCartItem;
    }

    public void RemoveShoppingCartItem(ShoppingCartItem shoppingCartItem)
    {
        _items.Remove(shoppingCartItem);
    }

    public Money TotalPrice
    {
        get
        {
            decimal totalprice = 0;
            foreach (var item in Items)
            {
                totalprice += item.Price.Value * item.Quantity;
            }
            return new Money(totalprice);
        }
    }
}
