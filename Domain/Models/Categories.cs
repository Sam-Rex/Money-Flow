using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Api.Domain.Models
{
    public class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public string Icon { get; set; }

        [ForeignKey("Type")]
        public Guid TypeId { get; set; }
        public CategoriesType Type { get; set; }
        public ICollection<MoneyFlow> Flows { get; set; }
    }
}