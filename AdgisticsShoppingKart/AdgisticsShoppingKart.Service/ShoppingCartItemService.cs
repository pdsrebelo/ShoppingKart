using System.Collections.Generic;
using AdgisticsShoppingKart.Data.Interfaces;
using AdgisticsShoppingKart.Data.Repositories;
using AdgisticsShoppingKart.Model;
using AdgisticsShoppingKart.Service.Interfaces;

namespace AdgisticsShoppingKart.Service
{
    public class ShoppingCartItemService : IShoppingCartItemService
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartItemService(IShoppingCartItemRepository shoppingCartItemRepository, IUnitOfWork unitOfWork)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
            _unitOfWork = unitOfWork;
        }

        public ShoppingCartItem AddOrUpdateShoppingCartItem(ShoppingCartItem shoppingCartItem, string shoppingCartGuid)
        {
            ShoppingCartItem dbItem = _shoppingCartItemRepository.GetByName(shoppingCartItem.Name);
            shoppingCartItem.ShoppingCartGuid = shoppingCartGuid;

            if (dbItem == null)
            {
                AddShoppingCartItem(shoppingCartItem);
                return shoppingCartItem;
            }

            dbItem.Quantity += shoppingCartItem.Quantity;
            EditShoppingCartItem(dbItem);
            return dbItem;
        }

        public void AddShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            _shoppingCartItemRepository.Add(shoppingCartItem);
        }

        public IEnumerable<ShoppingCartItem> GetShoppingCartItems()
        {
            return _shoppingCartItemRepository.GetAll();
        }

        public void EditShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            _shoppingCartItemRepository.Update(shoppingCartItem);
        }

        public bool DeleteShoppingCartItemByName(string name)
        {
            ShoppingCartItem dbItem = _shoppingCartItemRepository.GetByName(name);

            if (dbItem == null)
                return false;

            _shoppingCartItemRepository.Delete(dbItem);
            return true;
        }

        public void DeleteShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            _shoppingCartItemRepository.Delete(shoppingCartItem);
        }

        public void SaveShoppingCartItem()
        {
            _unitOfWork.Commit();
        }
    }
}