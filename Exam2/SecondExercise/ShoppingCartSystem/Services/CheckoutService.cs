namespace ShoppingCartSystem.services;

using ShoppingCartSystem.interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
public class CheckoutService
{
    private readonly List<IPProduct> _phisicalProducts;
    private readonly List<IDProduct> _digitalProducts;

    public CheckoutService(List<IPProduct> phisicalProducts, List<IDProduct> digitalProducts)
    {
        _phisicalProducts = phisicalProducts ?? throw new ArgumentNullException(nameof(phisicalProducts));
        _digitalProducts = digitalProducts ?? throw new ArgumentNullException(nameof(digitalProducts));
    }
    public void Checkout()
    {
        Console.WriteLine("\n=== Checkout Process ===");

        Console.WriteLine("Physical Items:");

        foreach (var item in _phisicalProducts)
        {
            try
            {
                item.Ship();
                Console.WriteLine($"- {item.Name}: Shipped (Weight: {item.Weight})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"- {item.Name}: Shipping failed - {ex.Message}");
            }
        }

        Console.WriteLine("\nDigital Items:");
        foreach (var item in _digitalProducts)
        {
            try
            {
                item.Download();
                Console.WriteLine($"- {item.Name}: Downloaded");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"- {item.Name}: Download failed - {ex.Message}");
            }
        }
    }
}
