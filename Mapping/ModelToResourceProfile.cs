using AutoMapper;
using Api.Domain.Models;
using Api.Resources;
using Api.Extensions;
namespace Api.Mapping
{
    public class ModelToResourceProfile:Profile
    {
        public ModelToResourceProfile()
        {

            //Mapping Category Model to Category Resource
            CreateMap<CategoriesType,TypeResource>();

            
            // Mapping Products to to Product Resource 
            CreateMap<Categories,CategoryResource>()
                .ForMember(destination=>destination.CategoryType,
                    conf=>conf.MapFrom(source=>source.Type));


            CreateMap<MoneyFlow, FlowResources>()
                .ForMember(destination => destination.categoryResource,
                    conf => conf.MapFrom(source => source.Categories));

        }
    }
}