namespace  ShoppingCartSystem.Services;

using System.Collections.Generic;
using ShoppingCartSystem.interfaces;
public class ShippingCalculator : IShippingCalculator
{
    public ShippingCalculator(List<IPProduct> phisicalItems)
    {
        PhisicalItems = phisicalItems;
    }

    public List<IPProduct> PhisicalItems { get; }

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