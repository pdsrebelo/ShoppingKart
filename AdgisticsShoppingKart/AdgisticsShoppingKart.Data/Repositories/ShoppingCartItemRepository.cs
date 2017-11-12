using AdgisticsShoppingKart.Data.Interfaces;
using AdgisticsShoppingKart.Model;

namespace AdgisticsShoppingKart.Data.Repositories
{
    public class ShoppingCartItemRepository : RepositoryBase<ShoppingCartItem>, IShoppingCartItemRepository
    {
        public ShoppingCartItemRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IShoppingCartItemRepository : IRepository<ShoppingCartItem>
    {
    }
}