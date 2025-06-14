namespace CoffeeShop.Interfaces;

// Component interface - defines the interface for both base objects and decorators
public interface ICoffee
{
  string GetDescription();
  decimal GetCost();
  int GetCalories();
  string GetSize();
  // TODO: Change to ingredient class (add all the properties that you think are needed)
  void  GetIngredients();

}