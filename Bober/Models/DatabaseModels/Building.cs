using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bober.Models.DatabaseModels
{
    public class Building
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("название")]
        [Required(ErrorMessage = "Введите название здания")]
        public string Name { get; set; }

        [DisplayName("этаж")]
        [Required(ErrorMessage = "Введите кол-во этажей")]
        public int FlorNumber { get; set; }

        [DisplayName("статус")]
        [Required(ErrorMessage = "Введите статус")]
        public string Status { get; set; }

        [DisplayName("Допы")]
        [Required(ErrorMessage = "Введите допки")]
        public string Bonus { get; set; }

        [DisplayName("район")]
        [Required(ErrorMessage = "Введите район")]
        public string DistrictID { get; set; }

        [DisplayName("застрройщик")]
        [Required(ErrorMessage = "Введите застройщика")]
        public int ZastrID { get; set; }
        [ForeignKey("ZastrID")]

        public Zastr Zastr { get; set; }
    }
}
