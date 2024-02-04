
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

        public async Task<UserIdLogin> GetUser()
        {
            try
            {
                Console.WriteLine($"Trying to get user");
                UserIdLogin login = new UserIdLogin();
                login.UserId = await userRepository.GetUser();
                Console.WriteLine($"login : {login.UserId}");
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
