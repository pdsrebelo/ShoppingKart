using AdgisticsShoppingKart.Data.Interfaces;

namespace AdgisticsShoppingKart.Data
{
    public class DbFactory : IDbFactory
    {
        private ShoppingKartContext _dbContext;

        public ShoppingKartContext Init()
        {
            return _dbContext ?? (_dbContext = new ShoppingKartContext());
        }
    }
}