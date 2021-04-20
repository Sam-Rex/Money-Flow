using AutoMapper;
using Api.Domain.Models.Account;
using Api.Domain.Models;
using Api.Resources;
using Api.Extensions;
namespace Api.Mapping{

    public class ResourceToModelProfile:Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveTypeResource,CategoriesType>();
            
            CreateMap<SaveCategoryResource,Categories>()
                .ForMember(entity=>entity.TypeId,
                    conf=>conf.MapFrom(model=>model.TypeId));


            CreateMap<SaveFlowResources,MoneyFlow>()
                .ForMember(entity => entity.CategoryId,
                    conf => conf.MapFrom(model => model.CategoryId));


            CreateMap<AccountResources, User>();
        }
    }
}