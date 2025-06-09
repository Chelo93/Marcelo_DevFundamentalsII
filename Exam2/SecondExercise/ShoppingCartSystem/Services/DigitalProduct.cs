
namespace ShoppingCartSystem.services;

using ShoppingCartSystem.interfaces;

public class DigitalProduct : IDProduct
{
  public string? Name { get; set; }
  public decimal Price { get; set; }
  public bool IsPhysical => false;
  public decimal Weight { get; set; }
  public string? DownloadUrl { get; set; }

  public void Ship()
  {
    throw new InvalidOperationException("Cannot ship digital products!");
  }

  public void Download()
  {
    Console.WriteLine($"Downloading {Name} from {DownloadUrl}");
  }

  public decimal CalculateShippingCost()
  {
    return 0;
  }
}