using ShopProduct.Shared;

namespace ShopProduct.Server.Repository
{
    public interface IUserRepository
    {
        Task<int> GetUser();
    }
}
