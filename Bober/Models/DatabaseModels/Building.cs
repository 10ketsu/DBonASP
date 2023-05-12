using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Bober.Models.DatabaseModels
{
    public class Building
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Название")]
        [Required(ErrorMessage = "Введите название здания")]
        public string Name { get; set; }

        [DisplayName("Этаж")]
        [Required(ErrorMessage = "Введите кол-во этажей")]
        public int FlorNumber { get; set; }

        [DisplayName("Статус")]
        [Required(ErrorMessage = "Введите статус")]
        public string Status { get; set; }

        [DisplayName("Допы")]
        [Required(ErrorMessage = "Введите допки")]
        public string Bonus { get; set; }

        //[DisplayName("Район")]
        //[Required(ErrorMessage = "Введите район")]
        //public string District { get; set; }

        //[DisplayName("Застройщик")]
        //[Required(ErrorMessage = "Введите застройщика")]
        //public string Zastr { get; set; }

        [ForeignKey("District")]
        [DisplayName("Район")]
        [Required(ErrorMessage = "Введите район")]
        public int DistrictID { get; set; }
        public District District { get; set; }


        [ForeignKey("Zastr")]
        [DisplayName("Застройщик")]
        [Required(ErrorMessage = "Введите застройщика")]
        public int ZastrID { get; set; }
        public Zastr Zastr { get; set; }

        //public List<Flat> Flats { get; set; }
    }
}
