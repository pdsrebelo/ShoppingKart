namespace AdgisticsShoppingKart.Data.Interfaces
{
    public interface IDbFactory
    {
        ShoppingKartContext Init();
    }
}