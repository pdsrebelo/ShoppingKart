using System.Linq;
using AdgisticsShoppingKart.Data.Interfaces;
using AdgisticsShoppingKart.Model;

namespace AdgisticsShoppingKart.Data.Repositories
{
    public class ShoppingCartRepository : RepositoryBase<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public ShoppingCart GetByGuid(string guid)
        {
            return DbContext.ShoppingCarts.SingleOrDefault(m => m.Guid == guid);
        }
    }

    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        ShoppingCart GetByGuid(string guid);
    }
}