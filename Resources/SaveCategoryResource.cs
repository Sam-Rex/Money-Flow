using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Resources
{
    public class SaveCategoryResource
    {
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Icon { get; set; }
        
        public Guid TypeId { get;set;}
        
        
    }
}