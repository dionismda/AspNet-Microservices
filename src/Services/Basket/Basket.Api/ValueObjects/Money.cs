namespace Basket.Api.ValueObjects;

public sealed class Money : ValueObject
{
    public decimal Value { get; private set; }

    public Money(decimal value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
