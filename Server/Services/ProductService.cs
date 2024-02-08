using ShopProduct.Server.Repository;
using ShopProduct.Shared;

namespace ShopProduct.Server.Services
{
    public class ProductService : IProductService
    {
        public IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<List<ProductItems>> ProductItems()
        {
            try
            {
                Console.WriteLine($"Trying to get Product Item List");
                var result = await productRepository.ProductItems();
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while trying to get product items err: {ex}");
                throw;
            }
            finally
            {
                Console.WriteLine($"Finishing get Product Items");
            }
        }
    }
}
