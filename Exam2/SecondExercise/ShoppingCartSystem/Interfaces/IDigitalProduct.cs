namespace ShoppingCartSystem.interfaces;

public interface IDProduct
{
    string? Name { get; set; }
    decimal Price { get; set; }
    bool IsPhysical { get; }
    string? DownloadUrl { get; set; }
    void Download();
}