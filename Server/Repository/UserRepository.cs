
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
			var query = @"SELECT password FROM users";
			var result = await dbConnection.ExecuteAsync(query);
			return result == 1;
		}

		public async Task<int> GetUserId(int userId)
        {

            DbConnection dbConnection = dbContext.Connection;
            var param = new { user_id = userId };
            var query = @"SELECT user_id FROM users";
            var result = await dbConnection.QueryFirstAsync<int>(query);
            return result;
        }
    }
}
