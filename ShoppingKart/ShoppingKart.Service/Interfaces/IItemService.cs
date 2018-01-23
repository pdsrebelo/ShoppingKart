using System.Collections.Generic;
using ShoppingKart.Model;

namespace ShoppingKart.Service.Interfaces
{
    public interface IItemService
    {
        void AddItem(Item item);

        IEnumerable<Item> GetItems();

        void EditItem(Item item);

        void DeleteItem(Item item);

        void SaveItem();
    }
}