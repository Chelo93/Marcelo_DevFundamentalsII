namespace ShoppingCartSystem.interfaces;

public interface IDiscountStrategy
{
    decimal CalculateDiscount(decimal subtotal);
}