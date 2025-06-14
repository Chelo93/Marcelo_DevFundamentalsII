using CoffeeShop.Interfaces;

namespace CoffeeShop.Components;

public abstract class BaseCoffee(string description, decimal baseCost, int baseCalories, string size) : ICoffee
{
  protected string _description = description;
  protected decimal _baseCost = baseCost;
  protected int _baseCalories = baseCalories;
  protected string _size = size; 
  // TODO: Replace with your ingredient class/record
  protected List<Ingredient> _baseIngredients = new List<Ingredient>
  {
      new Ingredient(
          name: "Coffee",
          cost: 0.50,
          calories: 2,
          quantity: 100,
          unit: "ml"
      ),
      new Ingredient(
          name: "Water",
          cost: 0.00,
          calories: 0,
          quantity: 100,
          unit: "ml"
      )
  };

  public virtual string GetDescription() => _description;
  public virtual decimal GetCost() => _baseCost;
  public virtual int GetCalories() => _baseCalories;
  public virtual string GetSize() => _size;
  public void GetIngredients()
  {
    foreach (var ingredient in _baseIngredients)
    {
      Console.WriteLine(ingredient.ToString());
    }
  }
}