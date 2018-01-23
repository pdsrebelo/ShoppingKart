using System.Collections.Generic;
using ShoppingKart.Data.Interfaces;
using ShoppingKart.Data.Repositories;
using ShoppingKart.Model;
using ShoppingKart.Service.Interfaces;

namespace ShoppingKart.Service
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddItem(Item item)
        {
            _itemRepository.Add(item);
        }

        public void SaveItem()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Item> GetItems()
        {
            return _itemRepository.GetAll();
        }

        public void EditItem(Item item)
        {
            _itemRepository.Update(item);
        }

        public void DeleteItem(Item item)
        {
            _itemRepository.Delete(item);
        }
    }
}