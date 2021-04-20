using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Resources
{
    public class SaveFlowResources
    {
        public float amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
