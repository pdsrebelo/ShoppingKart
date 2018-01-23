using ShoppingKart.Data.Interfaces;
using ShoppingKart.Model;

namespace ShoppingKart.Data.Repositories
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