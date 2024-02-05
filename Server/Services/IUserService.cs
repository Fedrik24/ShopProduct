using ShopProduct.Shared;

namespace ShopProduct.Server.Services
{
    public interface IUserService
    {
        Task<UserIdLogin> GetUserInfo(int userId, string password);
    }
}
