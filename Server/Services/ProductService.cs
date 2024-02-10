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

        public async Task<bool> CalculateCurrency(int userId, int itemType, int price)
        {
            try
            {
                int total = 0;
                if (userId <= 0) return false;
                
                int userCurrency = await productRepository.GetUserCurrency(userId);

                if (userCurrency < price) return false;

                bool checkProductType = await productRepository.IsProductTypeAvaible(itemType);

                if (!checkProductType) return false;

                total = userCurrency - price;

                var result = await productRepository.UpdateUserCurrency(userId, total);
                
                if (!result) return false;

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Something went wrong while trying to calculate : {ex}");
                throw;
            }
            finally
            {
                Console.WriteLine("Finishing Calculate User Currency");
            }
        }

        public async Task<bool> InsertUserProductHistory(UserPurchase userPurchase)
        {
            try
            {
                Console.WriteLine($"Trying to insert user product purchase for userId : {userPurchase.UserId}");
                // check userId exist or not.
                if (userPurchase.UserId <= 0) return false;
                var IsInserted = await productRepository.InsertUserProductHistory(userPurchase);
                if(IsInserted)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went wrong : " + ex.ToString());
                throw;
            }
            finally
            {
                Console.WriteLine($"Finishing Insert Purchase User History");
            }
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
