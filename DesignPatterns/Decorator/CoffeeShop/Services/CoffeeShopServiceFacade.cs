using CoffeeShop.Components;
using CoffeeShop.Interfaces;

namespace CoffeeShop.Services;

public class CoffeeShopServiceFacade
{
  private readonly Dictionary<string, Func<ICoffee>> _baseCoffees = new()
  {
    { "Espresso", () => new Espresso() },
    { "Americano", () => new Americano() },
    { "Latte", () => new Latte() },
    { "Mocha", () => new Mocha() },
    { "Cappuccino", () => new Cappuccino() }
  };

  public void ShowMenu()
  {
    Console.WriteLine("Coffee shop Menu");
    Console.WriteLine("Base coffees: ");

    foreach (var baseCoffee in _baseCoffees)
    {
      var cofee = baseCoffee.Value();
      Console.WriteLine($"""
      {baseCoffee.Key}: ${cofee.GetCost():F2} ({cofee.GetCalories()} calories)
      """);
    }

    Console.WriteLine("\nAvailable Add ons:");
    Console.WriteLine(" Milk (Regular/Soy/Coconut): $0.60-$0.90");
    Console.WriteLine(" Sugar (White/Brown/Stevia): $0.30-$0.60 per packet");
  }

  public ICoffee CreateCustomCoffee(string baseCoffeeType)
  {
    var coffeeCreator = _baseCoffees.FirstOrDefault(baseCoffee =>
      baseCoffee.Key == baseCoffeeType).Value ?? throw new ArgumentNullException(nameof(baseCoffeeType));

    return coffeeCreator();
  }

  // TODO: PRINT RECEIPT with Order, Size, Total Cost, Total calories (optional, ingredients)

      public static void PrintReceipt(ICoffee coffe, bool showIngredients = false)
    {
        Console.WriteLine("----- RECEIPT -----");
        Console.WriteLine($"Order: {coffe.GetDescription()}");
        Console.WriteLine($"Size: {coffe.GetSize}");
        Console.WriteLine($"Total Cost: ${coffe.GetCost():0.00}");
        Console.WriteLine($"Total Calories: {coffe.GetCalories}");

        if (showIngredients)
        {
            Console.WriteLine("Ingredients:");
            coffe.GetIngredients();
        }
        Console.WriteLine("-------------------");
    }
}