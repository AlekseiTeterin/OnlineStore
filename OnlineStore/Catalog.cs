namespace OnlineStore
{
    public class Catalog
    {
        public List<Product> Products { get; set; } = new()
        {
            new Product(1, "Чистый код", 100),
            new Product(1, "Чистая архитектура", 200),
            new Product(1, "Entity framework в действии", 100)
        };
    }
}
