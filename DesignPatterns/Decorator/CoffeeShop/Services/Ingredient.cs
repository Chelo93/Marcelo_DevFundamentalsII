public class Ingredient
{
    public string Name { get; set; }
    public double Cost { get; set; }
    public int Calories { get; set; }
    public string Unit { get; set; } // e.g., "ml", "g", "piece"
    public double Quantity { get; set; }
    public Ingredient(string name, double cost, int calories, double quantity, string unit, bool isAllergen = false, bool isVegan = true)
    {
        Name = name;
        Cost = cost;
        Calories = calories;
        Quantity = quantity;
        Unit = unit;
    }

    public override string ToString()
    {
        return $"{Name} ({Quantity}{Unit}) - {Calories} cal, ${Cost:0.00}";
    }
}