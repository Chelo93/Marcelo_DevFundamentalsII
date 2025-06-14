using CoffeeShop.Interfaces;

namespace CoffeeShop.Decorator;

// Base Decorator: Implements the component interface and has a reference to a component
public abstract class CoffeeDecorator(ICoffee coffee) : ICoffee
{
  protected ICoffee _coffee = coffee ?? throw new ArgumentNullException(nameof(coffee));

  // Default implementation delegates to the wrapped component
  public virtual string GetDescription() => _coffee.GetDescription();
  public virtual decimal GetCost() => _coffee.GetCost();
  public virtual int GetCalories() => _coffee.GetCalories();
  public virtual string GetSize() => _coffee.GetSize();
  public virtual void GetIngredients() => _coffee.GetIngredients(); 

}