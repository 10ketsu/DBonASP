using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.CodeAnalysis;

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

        [ForeignKey("District")]
        [DisplayName("Район")]
        [Required(ErrorMessage = "Введите район")]
        public int DistrictID { get; set; }
        [ValidateNever]
        public District District { get; set; }


        [ForeignKey("Zastr")]
        [DisplayName("Застройщик")]
        [Required(ErrorMessage = "Введите застройщика")]
        public int ZastrID { get; set; }
        [ValidateNever]
        public Zastr Zastr { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

        //public List<Flat> Flats { get; set; }
    }
}
