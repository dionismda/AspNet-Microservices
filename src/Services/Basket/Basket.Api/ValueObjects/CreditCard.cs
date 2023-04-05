namespace Basket.Api.ValueObjects;

public sealed class CreditCard : ValueObject
{
    public string CardName { get; private set; }
    public string CardNumber { get; private set; }
    public string Expiration { get; private set; }
    public string CVV { get; private set; }

    public CreditCard(string cardName, string cardNumber, string expiration, string cVV)
    {
        CardName = cardName;
        CardNumber = cardNumber;
        Expiration = expiration;
        CVV = cVV;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CardName;
        yield return CardNumber;
        yield return Expiration;
        yield return CVV;
    }
}
