using MediatR;

namespace CqrsMediatrExample
{
    public class FakeDataStore
    {
        private static List<Product> _products;
        public FakeDataStore()
        {
            _products = new List<Product>()
            {
                new Product {Id = 1, Name = "Test Product 1"},
                new Product {Id = 2, Name = "Test Product 2"},
                new Product {Id = 3, Name = "Test Product 3"},
            };
        }

        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }


        public async Task<IEnumerable<Product>> GetProducts() =>
            await Task.FromResult(_products);

        public async Task<Product> GetProductById(int id) =>
            await Task.FromResult(_products
                .Single(x => x.Id == id));

        public async Task<bool> UpdateProduct(Product product)
        {
            try
            {
                var productToUpdate = _products.Single(x => x.Id == product.Id);
                var index = _products.IndexOf(productToUpdate);
                _products[index] = product;
                await Task.CompletedTask;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteProduct(int Id)
        {

            try
            {
                var productToDelete = _products.Single(x => x.Id == Id);
                _products.Remove(productToDelete);
                await Task.CompletedTask;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task EventOccured(Product product, string evt)
        {
            _products.Single(x => x.Id == product.Id)
                .Name = $"{product.Name} evt: {evt}";
            await Task.CompletedTask;
        }
        
    }
}
