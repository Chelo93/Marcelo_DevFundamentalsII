namespace ShoppingCartSystem.interfaces;

using System.Collections.Generic;

public interface IShippingCalculator
{
    decimal CalculateShipping(IEnumerable<IPProduct> physicalItems);

}