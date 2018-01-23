using ShoppingKart.Data.Interfaces;

namespace ShoppingKart.Data
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