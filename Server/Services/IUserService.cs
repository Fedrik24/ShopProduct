using ShopProduct.Shared;

namespace ShopProduct.Server.Services
{
    public interface IUserService
    {
        Task<UserIdLogin> GetUser();
    }
}
