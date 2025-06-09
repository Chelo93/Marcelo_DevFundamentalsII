namespace ShoppingCartSystem.services;

using ShoppingCartSystem.interfaces;

public class PhysicalProduct : IPProduct
{
  public string? Name { get; set; }
  public decimal Price { get; set; }
  public int Stock { get; set; }
  public bool IsPhysical => true;
  public decimal Weight { get; set; }

  public void Ship()
  {
    Console.WriteLine($"Shipping {Name}");
    if (Stock <= 0)
    {
      throw new InvalidOperationException("Product out of stock!");
    }

    Stock--;
  }

  public void Download()
  {
    throw new InvalidOperationException("Cannot download physical products!");
  }

  public decimal CalculateShippingCost()
  {
    return Weight * 2.5m; 
  }
}
