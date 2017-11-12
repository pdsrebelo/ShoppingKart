using System.Collections.Generic;
using System.Linq;
using AdgisticsShoppingKart.Data.Interfaces;
using AdgisticsShoppingKart.Data.Repositories;
using AdgisticsShoppingKart.Model;
using AdgisticsShoppingKart.Service.Interfaces;

namespace AdgisticsShoppingKart.Service
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OfferService(IOfferRepository offerRepository, IUnitOfWork unitOfWork)
        {
            _offerRepository = offerRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddOffer(Offer offer)
        {
            _offerRepository.Add(offer);
        }

        public decimal GetTotal(ShoppingCart shoppingCart, IEnumerable<Item> items)
        {
            decimal total = 0;
            if (shoppingCart?.Items != null && items != null && items.Any())
            {
                foreach (ShoppingCartItem shoppingItem in shoppingCart.Items)
                {
                    Item item = items.SingleOrDefault(i => i.Name == shoppingItem.Name);

                    if (item != null)
                    {
                        // Check if it there's any promotion available
                        if (item.Offer != null)
                        {
                            int nrOfPromotions = shoppingItem.Quantity / item.Offer.Quantity;

                            decimal promotionTotal = nrOfPromotions * item.Offer.Value;

                            decimal subTotal = (shoppingItem.Quantity - (nrOfPromotions * item.Offer.Quantity)) * item.Price;

                            total += promotionTotal + subTotal;
                        }
                        else
                        {
                            total += shoppingItem.Quantity * item.Price;
                        }
                    }
                }
            }

            return total;
        }

        public void SaveOffer()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Offer> GetOffers()
        {
            return _offerRepository.GetAll();
        }

        public void EditOffer(Offer offer)
        {
            _offerRepository.Update(offer);
        }

        public void DeleteOffer(Offer offer)
        {
            _offerRepository.Delete(offer);
        }
    }
}