using System.Collections.Generic;
using AdgisticsShoppingKart.Model;

namespace AdgisticsShoppingKart.Service.Interfaces
{
    public interface IShoppingCartItemService
    {
        void AddShoppingCartItem(ShoppingCartItem shoppingCartItem);

        ShoppingCartItem AddOrUpdateShoppingCartItem(ShoppingCartItem shoppingCartItem, string shoppingCartGuid);

        IEnumerable<ShoppingCartItem> GetShoppingCartItems();

        void EditShoppingCartItem(ShoppingCartItem shoppingCartItem);

        void DeleteShoppingCartItem(ShoppingCartItem shoppingCartItem);

        void SaveShoppingCartItem();
    }
}