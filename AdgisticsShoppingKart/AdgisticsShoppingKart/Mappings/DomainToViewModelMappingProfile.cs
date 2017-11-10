using AdgisticsShoppingKart.Model;
using AdgisticsShoppingKart.Models;
using AutoMapper;

namespace AdgisticsShoppingKart.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Offer, OfferViewModel>();
            CreateMap<Item, ItemViewModel>()
                .ForMember(c => c.OfferView, opt => opt.MapFrom(src => Mapper.Map<Offer, OfferViewModel>(src.Offer)));
        }

        public override string ProfileName
        {
            get { return "DomainToModelMappings"; }
        }
    }
}