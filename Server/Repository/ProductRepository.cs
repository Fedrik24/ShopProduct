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
