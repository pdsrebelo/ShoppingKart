using System.Collections.Generic;
using ShoppingKart.Model;

namespace ShoppingKart.Service.Interfaces
{
    public interface IShoppingCartItemService
    {
        void AddShoppingCartItem(ShoppingCartItem shoppingCartItem);

        ShoppingCartItem AddOrUpdateShoppingCartItem(ShoppingCartItem shoppingCartItem, string shoppingCartGuid);

        IEnumerable<ShoppingCartItem> GetShoppingCartItems();

        void EditShoppingCartItem(ShoppingCartItem shoppingCartItem);

        void DeleteShoppingCartItem(ShoppingCartItem shoppingCartItem);

        bool DeleteShoppingCartItemByName(string name);

        void SaveShoppingCartItem();
    }
}