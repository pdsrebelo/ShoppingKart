using System.Collections.Generic;
using System.Linq;
using ShoppingKart.Data.Interfaces;
using ShoppingKart.Data.Repositories;
using ShoppingKart.Model;
using ShoppingKart.Service.Interfaces;

namespace ShoppingKart.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IUnitOfWork unitOfWork)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddShoppingCart(ShoppingCart shoppingCart)
        {
            _shoppingCartRepository.Add(shoppingCart);
        }

        public ShoppingCart GetShoppingCart(string name)
        {
            ShoppingCart shoppingCart = _shoppingCartRepository.GetByGuid(name);
            if (shoppingCart != null)
                return shoppingCart;

            ShoppingCart newShoppingCart = new ShoppingCart
            {
                Guid = name,
                Items = new List<ShoppingCartItem>()
            };

            // Create a new shopping cart
            AddShoppingCart(newShoppingCart);

            return newShoppingCart;
        }

        public IEnumerable<ShoppingCart> GetShoppingCarts()
        {
            return _shoppingCartRepository.GetAll();
        }

        public void DeleteShoppingCart(ShoppingCart shoppingCart)
        {
            _shoppingCartRepository.Delete(shoppingCart);
        }

        public bool DeleteItem(ShoppingCart shoppingCart, int id)
        {
            // Check if the shopping cart is empty
            if (shoppingCart.Items != null && shoppingCart.Items.Any())
            {
                ShoppingCartItem dbItem =
                    shoppingCart.Items.SingleOrDefault(c => c.Id == id);

                if (dbItem != null)
                {
                    shoppingCart.Items.Remove(dbItem);
                    _shoppingCartRepository.Update(shoppingCart);

                    return true;
                }
            }

            return false;
        }

        public void SaveShoppingCart()
        {
            _unitOfWork.Commit();
        }
    }
}