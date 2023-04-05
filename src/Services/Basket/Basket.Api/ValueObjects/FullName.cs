namespace Basket.Api.ValueObjects;

public sealed class FullName : ValueObject
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public FullName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }
}
