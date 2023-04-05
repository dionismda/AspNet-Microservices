namespace Basket.Api.ValueObjects;

public sealed class Address : ValueObject
{
    public string AddressLine { get; private set; }
    public string Country { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }

    public Address(string addressLine, string country, string state, string zipCode)
    {
        AddressLine = addressLine;
        Country = country;
        State = state;
        ZipCode = zipCode;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return AddressLine;
        yield return Country;
        yield return State;
        yield return ZipCode;
    }
}
