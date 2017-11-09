using AdgisticsShoppingKart.Model;
using AdgisticsShoppingKart.Models;
using AutoMapper;

namespace AdgisticsShoppingKart.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ItemModel, Item>();
        }

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

    }
}