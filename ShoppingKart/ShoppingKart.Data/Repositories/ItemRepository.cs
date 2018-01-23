using ShoppingKart.Data.Interfaces;
using ShoppingKart.Model;

namespace ShoppingKart.Data.Repositories
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