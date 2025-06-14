using CoffeeShop.Interfaces;

namespace CoffeeShop.Decorator;

// Concrete Decorators: Add specific functionality to the component
public class SugarDecorator(ICoffee coffee, int packets, string sugarType) : CoffeeDecorator(coffee)
{
  private readonly int _packets = packets;
  private readonly string _sugarType = sugarType;
  private decimal _costPerPacket = sugarType.ToLower() switch
  {
    "white" => 0.30m,
    "brown" => 0.40m,
    "stevia" => 0.50m,
    _ => 0.30m
  };

  public override string GetDescription()
  {
    var packetText = _packets == 1 ? "packet" : "packets";

    return $"{_coffee.GetDescription()}, {_packets} {packetText} of {_sugarType} Sugar";
  }

  public override decimal GetCost()
  {
    return _coffee.GetCost() + (_costPerPacket * _packets);
  }

  public override int GetCalories()
  {
    var caloriesPerPacket = _sugarType.ToLower() switch
    {
      "white" => 16,
      "brown" => 15,
      "stevia" => 0,
      _ => 16
    };

    return _coffee.GetCalories() + (caloriesPerPacket * _packets);
  }

  public override void GetIngredients()
  {
    _coffee.GetIngredients();
    var packetText = _packets == 1 ? "packet" : "packets";
    //$"{Name} ({Quantity}{Unit}) - {Calories} cal, ${Cost:0.00}";
    Console.WriteLine($"{_sugarType} Sugar ({_packets} {packetText}) - {GetCalories()} cal, {_costPerPacket*_packets:C}");
  }

}