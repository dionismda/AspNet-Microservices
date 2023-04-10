﻿namespace Discount.Api.ViewModels;

public sealed class CouponViewModel
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }
}
