// See https://aka.ms/new-console-template for more information
using CoffeeShop.Builder;
using CoffeeShop.Components;
using CoffeeShop.Decorator;
using CoffeeShop.Interfaces;
using CoffeeShop.Services;

var coffeeShop = new CoffeeShopServiceFacade();
coffeeShop.ShowMenu();

Console.WriteLine("----------");
ICoffee coffe1 = new Espresso();
coffe1 = new MilkDecorator(coffe1, "Regular");
coffe1 = new SugarDecorator(coffe1, 2, "Brown");
var result1 = coffe1.GetDescription();
Console.WriteLine(result1);
coffe1.GetIngredients();
Console.WriteLine($"Total Cost: {coffe1.GetCost():C}");


// coffeShop.PrintReceipt(coffe1, "Alberth");

// Builder reduced version
Console.WriteLine("----------");
var coffe2 = new CoffeeOrderBuilder(coffeeShop.CreateCustomCoffee("Americano"))
  .WithMilk()
  //.WithSugar(packets: 3)
  .Build();

var result2 = coffe2.GetDescription();

// ====== We are precessing other things ======
coffe2 = new SugarDecorator(coffe2, 2, "White");

Console.WriteLine(result2);
coffe2.GetIngredients();
Console.WriteLine($"Total Cost: {coffe2.GetCost():C}");

/*
BENEFITS OF DECORATOR PATTERN:
1. SINGLE RESPONSIBILITY PRINCIPLE:
  - Each decorator adds one and only one specific functionality.
  - Base coffee class focus only on core coffee properties.

2. OPEN/CLOSED PRINCIPLE:
  - Open for extension it is easy to add new decorators
  - It is easy to add new component (coffee types)
  - Closed for modification so, existing code doesn't change unless the bussiness rules change.

3. BONUS:
  - We introduce an easy way to enable the creation of an object to be dynamic.

BENEFITS OF FACADE PATTERN:
1. SINGLE RESPONSIBILITY PRINCIPLE:
  - The behavior that might be complex is enclosed in a single class
*/
