using ShopProduct.Shared;

namespace ShopProduct.Server.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductItems>> ProductItems();
        Task<bool> InsertUserProductHistory(UserPurchase userPurchase);
        Task<int> GetUserCurrency(int userId);
        Task<bool> IsProductTypeAvaible(int productType);
        Task<bool> UpdateUserCurrency(int userId, int currency);

    }
}
