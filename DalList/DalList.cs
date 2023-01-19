﻿using DalApi;

namespace Dal;

internal sealed class DalList : IDal
{
    private DalList() { }
    
    public static IDal Instance { get; } = new DalList();
    
    public ICustomer Customer { get; } = new DalCustomer();

    public IOrder Order { get; } = new DalOrder();

    public IOrderItem OrderItem { get; } = new DalOrderItem();

    public IProduct Product { get; } = new DalProduct();
}