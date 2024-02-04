using System.Data.Common;

namespace ShopProduct.Server
{
    public interface IDbContext
    {
        DbConnection Connection { get; }
    }
}
