namespace ShoppingCartSystem.services;

using ShoppingCartSystem.interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

public class DiscountStrategy : IDiscountStrategy
{
    private decimal _discount;
    private readonly List<IPProduct> _phisicalProducts;
    private readonly List<IDProduct> _digitalProducts;


    public DiscountStrategy(decimal subtotal, List<IPProduct> _phisicalProducts, List<IDProduct> _digitalProducts)
    {
        this._phisicalProducts = _phisicalProducts ?? throw new ArgumentNullException(nameof(_phisicalProducts));
        this._digitalProducts = _digitalProducts ?? throw new ArgumentNullException(nameof(_digitalProducts));
        CalculateDiscount(subtotal);
    }

    public decimal CalculateDiscount(decimal subtotal)
    {
        _discount = 0;

        if (subtotal > 100)
        {
            _discount = subtotal * 0.1m;
        }
        if (_phisicalProducts.Count > 5 || _digitalProducts.Count > 5)
        {
            _discount += 5;
        }
        return _discount;
    }

    public string GetDescription()
    {
        return $"Apply a discount of {_discount}";
    }
}