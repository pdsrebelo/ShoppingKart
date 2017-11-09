using AdgisticsShoppingKart.Model;
using AdgisticsShoppingKart.Models;
using AutoMapper;

namespace AdgisticsShoppingKart.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Item, ItemModel>();
        }

        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
    }
}