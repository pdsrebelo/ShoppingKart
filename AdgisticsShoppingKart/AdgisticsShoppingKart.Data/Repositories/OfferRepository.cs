using AdgisticsShoppingKart.Data.Interfaces;
using AdgisticsShoppingKart.Model;

namespace AdgisticsShoppingKart.Data.Repositories
{
    public class OfferRepository : RepositoryBase<Offer>, IOfferRepository
    {
        public OfferRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IOfferRepository : IRepository<Offer>
    {
    }
}