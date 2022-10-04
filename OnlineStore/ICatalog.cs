namespace OnlineStore
{
    public interface ICatalog
    {
        void AddProduct(Product product);
        IReadOnlyList<Product> GetProducts();
    }
}