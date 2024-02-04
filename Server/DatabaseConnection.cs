using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;
using System.Data.Common;

namespace ShopProduct.Server
{
    public class DatabaseConnection : DbContext, IDbContext
    {
        public DbConnection Connection => Database.GetDbConnection();

        public DatabaseConnection(DbContextOptions<DatabaseConnection> options)
    : base(options)
        {
        }

    }
}
