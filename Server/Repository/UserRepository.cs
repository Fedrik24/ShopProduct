
using Dapper;
using ShopProduct.Shared;
using System.Data.Common;

namespace ShopProduct.Server.Repository
{
    public class UserRepository : IUserRepository
    {
        private IDbContext dbContext;

        public UserRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

		public async Task<bool> CheckUserPassword(string password)
		{

			DbConnection dbConnection = dbContext.Connection;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
			var param = new { password = password };
			var query = @"SELECT password FROM users WHERE password = @password";
			var result = await dbConnection.QueryFirstAsync<string>(query,param);
			return result == password;
		}

        public async Task<int> GetUserId(int userId)
        {
            DbConnection dbConnection = dbContext.Connection;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            var param = new { user_id = userId };
            var query = @"SELECT user_id FROM users WHERE user_id = @user_id";
            var result = await dbConnection.QueryFirstAsync<int>(query, param);
            return result;
        }

        public async Task<int> GetUserIdByUsername(string username)
        {
            DbConnection dbConnection = dbContext.Connection;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            var param = new { username = username };
            var query = @"SELECT user_id FROM users WHERE username = @username";
            var result = await dbConnection.QueryFirstAsync<int>(query,param);
            return result;
        }

        public async Task<string> GetUserToken(int userId)
        {
            DbConnection dbConnection = dbContext.Connection;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            var param = new { user_id = userId };
            var query = @"SELECT token FROM users WHERE user_id = @user_id";
            var result = await dbConnection.QueryFirstAsync<string>(query, param);
            return result;
        }

        public async Task<bool> InsertUserToken(int userId, string token)
        {
            DbConnection dbConnection = dbContext.Connection;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            var param = new { 
                user_id = userId,
                token = token
            };
            var query = @"
            UPDATE public.users SET
            token = @token
            WHERE user_id = @user_id";
            var result = await dbConnection.ExecuteAsync(query, param);
            return result != 0;
        }
    }
}
