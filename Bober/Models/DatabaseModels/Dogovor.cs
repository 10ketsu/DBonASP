using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bober.Models.DatabaseModels
{
    public class Dogovor
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Дата заключения")]
        [Required(ErrorMessage = "Введите дату договора")]
        public DateTime DateStart { get; set; }

        [DisplayName("Дата окончания")]
        [Required(ErrorMessage = "Введите дату срока")]
        public DateTime DateFinish { get; set; }

        [DisplayName("Сумма")]
        [Required(ErrorMessage = "Введите цену")]
        public decimal Price { get; set; }


        [DisplayName("Номер сотрудника")]
        [Required(ErrorMessage = "Введите номер сотрудника")]
        public int SotrID { get; set; }
        [ForeignKey("SotrID")]
        [ValidateNever]
        public Sotrudnik Sotrudnik { get; set; }

        [DisplayName("Паспорт")]
        [Required(ErrorMessage = "Введите серию и номер")]

        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        [ValidateNever]
        public Client Client { get; set; }


        [DisplayName("Номер квартиры")]
        [Required(ErrorMessage = "Введите номер квартиры")]
        public int FlatID { get; set; }
        [ForeignKey("FlatID")]
        [ValidateNever]
        public Flat Flat { get; set; }
    }
}
