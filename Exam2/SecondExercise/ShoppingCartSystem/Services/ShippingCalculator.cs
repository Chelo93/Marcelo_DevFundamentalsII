namespace  ShoppingCartSystem.services;

using System.Collections.Generic;
using ShoppingCartSystem.interfaces;
public class ShippingCalculator : IShippingCalculator
{
    public decimal CalculateShipping(IEnumerable<IPProduct> physicalItems)
    {
        decimal totalShippingCost = 0;
        foreach (var item in physicalItems)
        {
            if (item.IsPhysical)
            {
                totalShippingCost += item.CalculateShippingCost();
            }
        }
        return totalShippingCost;
    }

}