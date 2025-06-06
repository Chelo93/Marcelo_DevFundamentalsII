namespace ShoppingCartSystem.interfaces;

public interface IPProduct
{
    string? Name { get; set; }
    decimal Price { get; set; }
    int Stock { get; set; }
    bool IsPhysical { get; }
    decimal Weight { get; set; }
    void Ship();
    decimal CalculateShippingCost();
}