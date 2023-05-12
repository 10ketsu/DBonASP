using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bober.Models.DatabaseModels
{
    public class Flat
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("номер")]
        [Required(ErrorMessage = "Введите номер квартиры")]
        public int FlatNumber { get; set; }

        [DisplayName("номер")]
        [Required(ErrorMessage = "Введите номер квартиры")]
        public string Status { get; set; }

        [DisplayName("кол-во комнат")]
        [Required(ErrorMessage = "Введите кол-во комнат")]
        public int RoomNumber { get; set; }

        [DisplayName("площадь")]
        [Required(ErrorMessage = "Введите площадь")]
        public decimal Sqyare { get; set; }

        [DisplayName("этаж")]
        [Required(ErrorMessage = "Введите этаж")]
        public int Flor { get; set; }

        //[DisplayName("здание")]
        //[Required(ErrorMessage = "Введите название здания")]
        //public string Building { get; set; }

        [DisplayName("здание")]
        [Required(ErrorMessage = "Введите название здания")]
        public int BuildingID { get; set; }
        [ForeignKey("BuildingID")]
        public Building Building { get; set; }

        //public List<Dogovor> Dogovors { get; set; }
    }
}
