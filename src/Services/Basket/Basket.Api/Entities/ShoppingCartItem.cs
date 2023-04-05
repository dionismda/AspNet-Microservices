namespace Basket.Api.Entities;

public class ShoppingCartItem
{
    public int Quantity { get; private set; }
    public string Color { get; private set; }
    public Money Price { get; private set; }
    public string ProductId { get; private set; }
    public string ProductName { get; private set; }

    public ShoppingCartItem(int quantity, string color, Money price, string productId, string productName)
    {
        Quantity = quantity;
        Color = color;
        Price = price;
        ProductId = productId;
        ProductName = productName;
    }
}
