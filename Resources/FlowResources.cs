using System;

namespace Api.Resources
{
    public class FlowResources
    {
        public Guid Id { get; set; }
        public float amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public CategoryResource categoryResource { get; set; }
    }
}
