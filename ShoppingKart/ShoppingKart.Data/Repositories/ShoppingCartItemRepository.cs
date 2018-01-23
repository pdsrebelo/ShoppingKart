using System.Linq;
using ShoppingKart.Data.Interfaces;
using ShoppingKart.Model;

namespace ShoppingKart.Data.Repositories
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