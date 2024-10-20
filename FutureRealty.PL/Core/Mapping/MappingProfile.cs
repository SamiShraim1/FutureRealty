using AutoMapper;
using FutureRealty.DAL.Models;
using FutureRealty.PL.Areas.Dashboard.ViewModels;

namespace FutureRealty.PL.Core.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile() 
        {
            CreateMap<ServiceFormVM, Service>().ReverseMap();
            CreateMap<Service, ServicesVM>();
            CreateMap<Service, ServiceDetailsVM>();

            CreateMap<PortfolioFormVM, Portfolio>().ReverseMap();
            CreateMap<Portfolio, PortfoliosVM>();
            CreateMap<Portfolio, PortfolioDetailsVM>();


            CreateMap<ItemformVM, Item>().ReverseMap();
            CreateMap<Item, ItemsVM>();
            CreateMap<Item, ItemDetailsVM>();

        }
        
    }
}
