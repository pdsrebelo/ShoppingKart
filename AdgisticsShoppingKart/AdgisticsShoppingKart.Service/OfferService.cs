using System.Collections.Generic;
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