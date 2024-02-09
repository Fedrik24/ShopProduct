using ShopProduct.Shared;

namespace ShopProduct.Server.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductItems>> ProductItems();
        Task<bool> InsertUserProductHistory(UserPurchase userPurchase);
    }
}
