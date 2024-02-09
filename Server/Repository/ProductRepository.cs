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

        public async Task<List<ProductItems>> ProductItems()
        {
            DbConnection dbConnection = dbContext.Connection;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            var query = @"SELECT * FROM product";
            var result = await dbConnection.QueryAsync<ProductItems>(query);
            return result.ToList();
        }
    }
}
