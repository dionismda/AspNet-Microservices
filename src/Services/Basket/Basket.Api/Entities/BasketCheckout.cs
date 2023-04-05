namespace Basket.Api.Entities;

public class BasketCheckout
{
    public string UserName { get; private set; }
    public Money TotalPrice { get; private set; }
    public FullName Name { get; private set; }
    public Email EmailAddress { get; private set; }
    public Address Address { get; private set; }
    public CreditCard CreditCard { get; private set; }
    public int PaymentMethod { get; private set; }

    public BasketCheckout(string userName, Money totalPrice, FullName name, Email emailAddress, 
                          Address address, CreditCard creditCard, int paymentMethod)
    {
        UserName = userName;
        TotalPrice = totalPrice;
        Name = name;
        EmailAddress = emailAddress;
        Address = address;
        CreditCard = creditCard;
        PaymentMethod = paymentMethod;
    }
}
