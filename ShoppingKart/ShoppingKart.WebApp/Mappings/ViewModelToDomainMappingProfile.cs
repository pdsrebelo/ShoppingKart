using System.Collections.Generic;
using AutoMapper;
using ShoppingKart.Model;
using ShoppingKart.WebApp.Models;

namespace ShoppingKart.WebApp.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<OfferViewModel, Offer>();
            CreateMap<ItemViewModel, Item>()
                .ForMember(c => c.Offer, opt => opt.MapFrom(src => Mapper.Map<OfferViewModel, Offer>(src.OfferView)));

            CreateMap<ShoppingCartItemViewModel, ShoppingCartItem>();
            CreateMap<ShoppingCartViewModel, ShoppingCart>()
                .ForMember(c => c.Items, opt => opt
                    .MapFrom(src => Mapper.Map<IEnumerable<ShoppingCartItemViewModel>, IEnumerable<ShoppingCartItem>>(src.Items)));
        }

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

    }
}