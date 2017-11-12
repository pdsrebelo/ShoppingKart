using AdgisticsShoppingKart.Data.Interfaces;
using AdgisticsShoppingKart.Model;

namespace AdgisticsShoppingKart.Data.Repositories
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IItemRepository : IRepository<Item>
    {
    }
}