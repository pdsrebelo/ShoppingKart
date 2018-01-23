using System.Linq;
using ShoppingKart.Data.Interfaces;
using ShoppingKart.Model;

namespace ShoppingKart.Data.Repositories
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