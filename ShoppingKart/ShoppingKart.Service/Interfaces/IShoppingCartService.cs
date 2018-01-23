using System.Collections.Generic;
using ShoppingKart.Model;

namespace ShoppingKart.Service.Interfaces
{
    public interface IShoppingCartService
    {
        void AddShoppingCart(ShoppingCart shoppingCart);

        ShoppingCart GetShoppingCart(string guid);

        IEnumerable<ShoppingCart> GetShoppingCarts();

        bool DeleteItem(ShoppingCart shoppingCart, int id);

        void DeleteShoppingCart(ShoppingCart shoppingCart);

        void SaveShoppingCart();
    }
}