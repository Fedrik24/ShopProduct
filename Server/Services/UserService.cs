
using ShopProduct.Server.Repository;
using ShopProduct.Shared;

namespace ShopProduct.Server.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // Ganti ke Authenticate saja. 
        public async Task<UserIdLogin> GetUserInfo(int userId, string password)
        {
            try
            {
                UserIdLogin login = new UserIdLogin();
                login.UserId = await userRepository.GetUserId(userId);
                var checkPassword = await userRepository.CheckUserPassword(password);
                return login;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong : {ex}");
                throw;
            }
            finally
            {
                Console.WriteLine($"Finishing log");
            }
        }
    }
}
