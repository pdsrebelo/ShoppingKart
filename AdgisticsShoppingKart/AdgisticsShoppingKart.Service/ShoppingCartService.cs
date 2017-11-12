using System.Collections.Generic;
using System.Linq;
using AdgisticsShoppingKart.Data.Interfaces;
using AdgisticsShoppingKart.Data.Repositories;
using AdgisticsShoppingKart.Model;
using AdgisticsShoppingKart.Service.Interfaces;

namespace AdgisticsShoppingKart.Service
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

        public ShoppingCartItem EditShoppingCart(ShoppingCart shoppingCart, ShoppingCartItem item)
        {
            ShoppingCartItem retItem = item;

            // Check if the shopping cart is empty
            if (shoppingCart.Items == null || !shoppingCart.Items.Any())
            {
                shoppingCart.Items = new List<ShoppingCartItem> { item };
            }
            else
            {
                ShoppingCartItem dbItem =
                    shoppingCart.Items.SingleOrDefault(c => c.Id == item.Id);

                if (dbItem != null)
                {
                    // If this item already exists, then we only update it's quantity
                    dbItem.Quantity += item.Quantity;
                    retItem = dbItem;
                }
                else
                {
                    // Otherwise we create a new item
                    shoppingCart.Items.Add(item);
                }
            }

            // Update the shopping cart
            _shoppingCartRepository.Update(shoppingCart);

            return retItem;
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