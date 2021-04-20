using System;
namespace Api.Resources
{
    public class CategoryResource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public TypeResource CategoryType { get; set; }
        
    }
}
