using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bober.Models.DatabaseModels
{
    public class District
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Район")]
        [Required(ErrorMessage = "Введите район")]
        public string Name { get; set; }

        [DisplayName("местоположение")]
        [Required(ErrorMessage = "Введите местоположение")]
        public string Location { get; set; }

        //public List<Building> Buildings { get; set; }
    }
}
