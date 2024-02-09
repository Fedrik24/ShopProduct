using ShopProduct.Shared;

namespace ShopProduct.Server.Services
{
    public interface IProductService
    {
        Task<List<ProductItems>> ProductItems();
        Task<bool> InsertUserProductHistory(UserPurchase userPurchase);
    }
}
