namespace ShoppingCartSystem.services;

using ShoppingCartSystem.interfaces;

public class DisplayService
{
    private readonly List<IPProduct> _phisicalProducts;
    private readonly List<IDProduct> _digitalProducts;

    public DisplayService(List<IPProduct> phisicalProducts, List<IDProduct> digitalProducts)
    {
        _phisicalProducts = phisicalProducts ?? throw new ArgumentNullException(nameof(phisicalProducts));
        _digitalProducts = digitalProducts ?? throw new ArgumentNullException(nameof(digitalProducts));
    }

    public void DisplayProducts()
    {
        Console.WriteLine("\n=== Shopping Cart ===");

        Console.WriteLine("Physical Products:");
        DisplayPhysicalProducts();

        Console.WriteLine("\nDigital Products:");
        DisplayDigitalProducts();
    }

    private void DisplayPhysicalProducts()
    {
        if (_phisicalProducts.Count == 0)
        {
            Console.WriteLine("No physical products available.");
            return;
        }
        
        var grouped = _phisicalProducts.GroupBy(p => p.Name);

        foreach (var item in _phisicalProducts.GroupBy(p => p.Name))
        {
            var product = item.First();
            var quantity = item.Count();
            Console.WriteLine($"{product.Name} x{quantity} - ${product.Price * quantity:F2}");
        }
    }

    private void DisplayDigitalProducts()
    {
        if (_digitalProducts.Count == 0)
        {
            Console.WriteLine("No digital products available.");
            return;
        }

        foreach (var item in _digitalProducts)
        {
            Console.WriteLine($"{item.Name} - ${item.Price:F2}");
        } 

    }
}