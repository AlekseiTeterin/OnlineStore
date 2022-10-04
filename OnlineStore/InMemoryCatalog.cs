namespace OnlineStore
{
    public class InMemoryCatalog : ICatalog
    {
        private readonly object _syncObj = new();
        private List<Product> Products { get; } = new()
        {
            new Product(1, "Чистый код", 100),
            new Product(1, "Чистая архитектура", 200),
            new Product(1, "Entity framework в действии", 100)
        };

        public void AddProduct(Product product)
        {
            lock (_syncObj)
            {
                Products.Add(product);
            }
        }

        public IReadOnlyList<Product> GetProducts()
        {
            lock (_syncObj)
            {
                if(DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                {
                    return Products
                            .Select(product => new Product(product.Id, product.Name, product.Price*1.5m))
                            .ToList();
                }
                return Products.ToList();
            }
        }


    }
}
