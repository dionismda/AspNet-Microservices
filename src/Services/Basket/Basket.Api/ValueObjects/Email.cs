﻿namespace Basket.Api.ValueObjects;

public sealed class Email : ValueObject
{
    public string Value { get; private set; }

    public Email(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}