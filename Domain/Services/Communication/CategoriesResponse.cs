using Api.Domain.Models;
namespace Api.Domain.Services.Communication
{
    public class CategoriesResponce:BaseResponce
    {
        public Categories Categories { get;private set; }
        private CategoriesResponce(bool success,string message, Categories categories) :base(success,message){
            Categories = categories;
        }

        public CategoriesResponce(Categories categories) :this(true,string.Empty, categories) {}

        public CategoriesResponce(string message):this(false,message,null)
        {
            
        }
    }
}