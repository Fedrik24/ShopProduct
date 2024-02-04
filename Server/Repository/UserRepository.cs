
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

        public async Task<int> GetUser()
        {
            try
            {
                DbConnection dbConnection = dbContext.Connection;
                var query = @"SELECT id FROM users";
                var result = await dbConnection.QueryFirstAsync<int>(query);
                return result;
            }catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
