using System.Linq;
using AdgisticsShoppingKart.Data.Interfaces;
using AdgisticsShoppingKart.Model;

namespace AdgisticsShoppingKart.Data.Repositories
{
    public class ShoppingCartItemRepository : RepositoryBase<ShoppingCartItem>, IShoppingCartItemRepository
    {
        public ShoppingCartItemRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public ShoppingCartItem GetByName(string name)
        {
            return DbContext.ShoppingCartItems.SingleOrDefault(m => m.Name == name);
        }
    }

    public interface IShoppingCartItemRepository : IRepository<ShoppingCartItem>
    {
        ShoppingCartItem GetByName(string name);
    }
}