using ShopProduct.Shared;

namespace ShopProduct.Server.Services
{
    public interface IUserService
    {
        Task<UserLoginData> GetUserInfo(string username, string password);
        Task<int> GetUserId(int userId);
        Task<bool> InsertUserToken(int userId, string token);
        Task<UserLoginData> GetUserByUserId(int userId);
        Task<bool> Register(RegisterData registerData);
    }
}
