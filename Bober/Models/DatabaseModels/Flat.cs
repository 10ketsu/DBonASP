using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Bober.Models.DatabaseModels
{
    public class Flat
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Номер кваритры")]
        [Required(ErrorMessage = "Введите номер квартиры")]
        public int FlatNumber { get; set; }

        [DisplayName("Статус")]
        [Required(ErrorMessage = "Введите статус квартиры")]
        public string Status { get; set; }

        [DisplayName("Кол-во комнат")]
        [Required(ErrorMessage = "Введите кол-во комнат")]
        public int RoomNumber { get; set; }

        [DisplayName("Площадь")]
        [Required(ErrorMessage = "Введите площадь")]
        public decimal Sqyare { get; set; }

        [DisplayName("Этаж")]
        [Required(ErrorMessage = "Введите этаж")]
        public int Flor { get; set; }

        [ForeignKey("BuildingId")]
        [DisplayName("Здание")]
        [Required(ErrorMessage = "Введите название здания")]
        public int BuildingID { get; set; }
        [ValidateNever]
        public Building Building { get; set; }
    }
}
