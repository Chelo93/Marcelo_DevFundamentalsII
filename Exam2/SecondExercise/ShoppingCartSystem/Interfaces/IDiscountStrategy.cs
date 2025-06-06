namespace ShoppingCartSystem.interfaces;

public interface IDiscountStrategy
{
    decimal CalculateDiscount(decimal subtotal, List<IPProduct>? physicalProducts, List<IDProduct>? digitalProducts);
}