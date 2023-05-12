using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bober.Models.DatabaseModels
{
    public class Dogovor
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("дата")]
        [Required(ErrorMessage = "Введите дату договора")]
        public DateTime DateStart { get; set; }

        [DisplayName("срок")]
        [Required(ErrorMessage = "Введите дату срока")]
        public DateTime DateFinish { get; set; }

        [DisplayName("цена")]
        [Required(ErrorMessage = "Введите цену")]
        public decimal Price { get; set; }

        //[DisplayName("Сотрудник")]
        //[Required(ErrorMessage = "Введите сотрудника")]
        //public string Sotr { get; set; }

        //[DisplayName("паспорт")]
        //[Required(ErrorMessage = "Введите серию и номер")]
        //[StringLength(10, ErrorMessage = "Длинна не может быть более {1} символов")]
        //public string Client { get; set; }

        //[DisplayName("Квартира")]
        //[Required(ErrorMessage = "Введите номер квартиры")]
        //public string Flat { get; set; }

        [DisplayName("Номер")]
        [Required(ErrorMessage = "Введите номер сотрудника")]
        public int SotrID { get; set; }
        [ForeignKey("SotrID")]
        public Sotrudnik Sotrudnik { get; set; }

        [DisplayName("паспорт")]
        [Required(ErrorMessage = "Введите серию и номер")]
        [StringLength(10, ErrorMessage = "Длинна не может быть более {1} символов")]
        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        public Client Client { get; set; }


        [DisplayName("номер")]
        [Required(ErrorMessage = "Введите номер квартиры")]
        public int FlatID { get; set; }
        [ForeignKey("FlatID")]
        public Flat Flat { get; set; }

        //public List<Bill> Bills { get; set; } 
    }
}
