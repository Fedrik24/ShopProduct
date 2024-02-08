
using ShopProduct.Server.Repository;
using ShopProduct.Shared;
using System.Linq.Dynamic.Core.Tokenizer;

namespace ShopProduct.Server.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<int> GetUserId(int userId)
        {
            try
            {
                return await userRepository.GetUserId(userId);
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Something went wrong while trying to get userId : {userId} err : {ex}");
                throw;
            }
            finally
            {
                Console.WriteLine($"Finishing log");
            }
        }

        public async Task<UserLoginData> GetUserInfo(string username, string password)
        {
            try
            {
                UserLoginData login = new UserLoginData();
                var userId = await userRepository.GetUserIdByUsername(username);
                if(userId > 0)
                {
                    var checkPassword = await userRepository.CheckUserPassword(password);
                    if(!checkPassword) return login = new UserLoginData();
                    login.Username = username;
                    login.Password = password;
                    login.UserId = userId;
                }
                else
                {
                    login = new UserLoginData();
                }
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

        public async Task<string> GetUserToken(int userId)
        {
            try
            {
                Console.WriteLine($"Trying to get userId :{userId} Token");
                var result = await userRepository.GetUserToken(userId);
                if (string.IsNullOrEmpty(result))
                {
                    return String.Empty;
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong : {e}");
                throw;
            }
            finally
            {
                Console.WriteLine($"Finishing log");
            }
        }

        public Task<bool> InsertUserToken(int userId, string token)
        {
            try
            {
                return userRepository.InsertUserToken(userId, token);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Something went wrong : {e}");
                throw;
            }
            finally
            {
                Console.WriteLine($"Finishing log");
            }
        }
    }
}
