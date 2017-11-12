using System.Collections.Generic;
using AdgisticsShoppingKart.Model;

namespace AdgisticsShoppingKart.Service.Interfaces
{
    public interface IOfferService
    {
        void AddOffer(Offer offer);

        IEnumerable<Offer> GetOffers();

        void EditOffer(Offer offer);

        void DeleteOffer(Offer offer);

        decimal GetTotal(ShoppingCart shoppingCart, IEnumerable<Item> items);

        void SaveOffer();
    }
}