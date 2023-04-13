﻿namespace Shopping.Aggregator.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
}
