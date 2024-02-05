using ShopProduct.Shared;

namespace ShopProduct.Server.Repository
{
    public interface IUserRepository
    {
        Task<int> GetUserId(int userId);
        Task<bool> CheckUserPassword(string password);
	}
}
