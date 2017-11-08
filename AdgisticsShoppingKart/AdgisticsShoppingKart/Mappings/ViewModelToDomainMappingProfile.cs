using AdgisticsShoppingKart.Model;
using AdgisticsShoppingKart.Models;
using AutoMapper;

namespace AdgisticsShoppingKart.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

//        protected override void Configure()
//        {
//            CreateMap<ItemModel, Item>();
//        }
    }
}