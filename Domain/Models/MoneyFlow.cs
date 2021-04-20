using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Api.Domain.Models
{
    public class MoneyFlow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public float amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        [ForeignKey("Categories")]
        public Guid CategoryId { get; set; }
        public Categories Categories { get; set; }
        
    }
}