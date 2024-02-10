using Dapper;
using ShopProduct.Shared;
using System.Data.Common;

namespace ShopProduct.Server.Repository
{
    public class ProductRepository : IProductRepository
    {
        private IDbContext dbContext;

        public ProductRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> GetUserCurrency(int userId)
        {
            DbConnection dbConnection = dbContext.Connection;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            var param = new { user_id = userId };
            var query = @"SELECT currency FROM user_currency WHERE user_id = @user_id";
            var result = await dbConnection.QueryFirstOrDefaultAsync<int>(query, param);
            return result;
        }

        public async Task<bool> InsertUserProductHistory(UserPurchase userPurchase)
        {
            DbConnection dbConnection = dbContext.Connection;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            var param = new
            {
                user_id = userPurchase.UserId,
                product_type = userPurchase.ProductType,
                price = userPurchase.Price,
                amount = userPurchase.Amount,

            };
            var query = @"INSERT INTO user_history(user_id, product_type, price, amount) VALUES (@user_id, @product_type, @price, @amount)";
            var result = await dbConnection.ExecuteAsync(query, param);
            return result == 1;
        }

        public async Task<bool> IsProductTypeAvaible(int productType)
        {
            DbConnection dbConnection = dbContext.Connection;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            var param = new { product_type = productType };
            var query = @"SELECT product_type FROM product WHERE product_type = @product_type LIMIT 1";
            var result = await dbConnection.ExecuteAsync(query, param);
            return result != 0;
        }

        public async Task<List<ProductItems>> ProductItems()
        {
            DbConnection dbConnection = dbContext.Connection;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            var query = @"SELECT * FROM product";
            var result = await dbConnection.QueryAsync<ProductItems>(query);
            return result.ToList();
        }

        public async Task<bool> UpdateUserCurrency(int userId, int currency)
        {
            DbConnection dbConnection = dbContext.Connection;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            var param = new
            {
                user_id = userId,
                currency = currency
            };
            var query = @"UPDATE user_currency SET currency = @currency WHERE user_id = @user_id";
            var result = await dbConnection.ExecuteAsync(query, param);
            return result == 1;
        }
    }
}
