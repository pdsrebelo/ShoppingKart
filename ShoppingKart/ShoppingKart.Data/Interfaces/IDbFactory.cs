namespace ShoppingKart.Data.Interfaces
{
    public interface IDbFactory
    {
        ShoppingKartContext Init();
    }
}