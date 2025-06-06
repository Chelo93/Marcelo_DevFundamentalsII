namespace ShoppingCartSystem.services;

using ShoppingCartSystem.interfaces;

public class ShoppingCart
{
  private readonly IDiscountStrategy? discountStrategy;
  private readonly IShippingCalculator? shippingCalculator;
  private List<IPProduct> phisicalItems = [];
  private List<IDProduct> digitalItems = [];

    public ShoppingCart(IDiscountStrategy discountStrategy, IShippingCalculator shippingCalculator)
    {
        this.discountStrategy = discountStrategy;
        this.shippingCalculator = shippingCalculator;
    }

  public void AddItem(IPProduct product, int quantity = 1)
  {
    for (int i = 0; i < quantity; i++)
    {
      phisicalItems.Add(product);
    }

    Console.WriteLine($"Added {quantity} x {product.Name} to cart");
  }

  public void AddItem(IDProduct product, int quantity = 1)
  {
    for (int i = 0; i < quantity; i++)
    {
      digitalItems.Add(product);
    }

    Console.WriteLine($"Added {quantity} x {product.Name} to cart");
  }

  public decimal CalculateTotal()
  {
    decimal subtotalP = phisicalItems.Sum(item => item.Price);
    decimal subtotalD = digitalItems.Sum(item => item.Price);
    decimal subtotal = subtotalP + subtotalD;
    decimal shipping = shippingCalculator!.CalculateShipping(phisicalItems);
    decimal discount = discountStrategy!.CalculateDiscount(subtotal, phisicalItems, digitalItems);

    Console.WriteLine($"\nSutotal: ${subtotal:F2}"); 
    Console.WriteLine($"Shiping: ${shipping:F2}"); 
    Console.WriteLine($"Discount: ${discount:F2}"); 
    return subtotal + shipping - discount;
  }

  public void Checkout()
  {
    var checkout = new CheckoutService(phisicalItems, digitalItems);
    checkout.Checkout();  
  }

  public void DisplayCart()
  {
    var display = new DisplayService(phisicalItems, digitalItems);
    display.DisplayProducts();
    Console.WriteLine($"Total to Pay: ${CalculateTotal():F2}"); 
  }
}
