using CoffeeShop.Interfaces;

namespace CoffeeShop.Decorator;

// Concrete Decorators: Add specific functionality to the component
public class MilkDecorator(ICoffee coffee, string milkType) : CoffeeDecorator(coffee)
{
  private readonly string _milkType = milkType;
  private readonly decimal _additionalCost = milkType.ToLower() switch
  {
    "regular" => 0.60m,
    "soy" => 0.75m,
    "coconut" => 0.90m,
    _ => 0.60m
  };
  private readonly int _additionalCalories = milkType.ToLower() switch
  {
    "regular" => 150,
    "soy" => 50,
    "coconut" => 70,
    _ => 150
  };

  public override string GetDescription()
  {
    return $"{_coffee.GetDescription()}, {_milkType} Milk";
  }

  public override decimal GetCost()
  {
    return _coffee.GetCost() + _additionalCost;
  }

  public override int GetCalories()
  {
    return _coffee.GetCalories() + _additionalCalories;
  }

  public override void GetIngredients()
  {
    _coffee.GetIngredients();
    //$"{Name} ({Quantity}{Unit}) - {Calories} cal, ${Cost:0.00}";
    Console.WriteLine($"{_milkType} Milk -  {_additionalCalories} cal, {_additionalCost:C}");
  }
}