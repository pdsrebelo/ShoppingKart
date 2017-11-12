using System.Collections.Generic;
using AdgisticsShoppingKart.Model;

namespace AdgisticsShoppingKart.Service.Interfaces
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