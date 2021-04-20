using Api.Domain.Models;
namespace Api.Domain.Services.Communication
{
    public class CategoryTypeResponce:BaseResponce
    {
        
        
        public CategoriesType CategoriesType { get;private set; }
        private CategoryTypeResponce(bool success,string message, CategoriesType categoriesType) :base(success,message){
            CategoriesType = categoriesType;
        }

        public CategoryTypeResponce(CategoriesType categoriesType) :this(true,string.Empty, categoriesType) {}

        public CategoryTypeResponce(string message):this(false,message,null)
        {
            
        }
    }
}