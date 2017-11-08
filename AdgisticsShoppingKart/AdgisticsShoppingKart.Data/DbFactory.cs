using AdgisticsShoppingKart.Data.Interfaces;

namespace AdgisticsShoppingKart.Data
{
    public class DbFactory : IDbFactory
    {
        private ShoppingKartEntities _dbContext;

        public ShoppingKartEntities Init()
        {
            return _dbContext ?? (_dbContext = new ShoppingKartEntities());

        }
    }
}