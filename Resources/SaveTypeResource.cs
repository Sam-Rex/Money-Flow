using System.ComponentModel.DataAnnotations;
namespace Api.Resources
{
    public class SaveTypeResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description{ get; set; }
        public string IconPath { get; set; }

    }
}