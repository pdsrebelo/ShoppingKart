using AdgisticsShoppingKart.Model;
using AdgisticsShoppingKart.Models;
using AutoMapper;

namespace AdgisticsShoppingKart.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<OfferViewModel, Offer>();
            CreateMap<ItemViewModel, Item>()
                .ForMember(c => c.Offer, opt => opt.MapFrom(src => Mapper.Map<OfferViewModel, Offer>(src.OfferView)));
        }

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

    }
}