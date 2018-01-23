using System.Collections.Generic;
using AutoMapper;
using ShoppingKart.Model;
using ShoppingKart.WebApp.Models;

namespace ShoppingKart.WebApp.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Offer, OfferViewModel>();
            CreateMap<Item, ItemViewModel>()
                .ForMember(c => c.OfferView, opt => opt.MapFrom(src => Mapper.Map<Offer, OfferViewModel>(src.Offer)));

            CreateMap<ShoppingCartItem, ShoppingCartItemViewModel>();
            CreateMap<ShoppingCart, ShoppingCartViewModel>()
                .ForMember(c => c.Items, opt => opt
                    .MapFrom(src => Mapper.Map<IEnumerable<ShoppingCartItem>, IEnumerable<ShoppingCartItemViewModel>>(src.Items)));
        }

        public override string ProfileName
        {
            get { return "DomainToModelMappings"; }
        }
    }
}