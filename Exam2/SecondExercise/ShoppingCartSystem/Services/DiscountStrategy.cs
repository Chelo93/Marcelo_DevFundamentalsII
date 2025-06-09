namespace ShoppingCartSystem.services;

using ShoppingCartSystem.interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

public class DiscountStrategy : IDiscountStrategy
{
    private decimal _discount;

    public decimal CalculateDiscount(decimal subtotal, List<IPProduct>? physicalProducts, List<IDProduct>? digitalProducts)
    {
        _discount = 0;

        if (subtotal > 100)
        {
            _discount = subtotal * 0.1m;
        }
        if (physicalProducts!.Count > 5 || digitalProducts!.Count > 5)
        {
            _discount += 5;
        }
        return _discount;
    }

}