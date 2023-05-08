using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bober.Models.DatabaseModels
{
    public class Dogovor
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("дата")]
        [Required(ErrorMessage = "Введите дату договора")]
        public DateTime DateStart { get; set; }

        [DisplayName("срок")]
        [Required(ErrorMessage = "Введите дату срока")]
        public DateTime DateFinish { get; set; }

        [DisplayName("цена")]
        [Required(ErrorMessage = "Введите цену")]
        public decimal Price { get; set; }

        [DisplayName("Номер")]
        [Required(ErrorMessage = "Введите номер сотрудника")]
        public int SotrID { get; set; }

        [DisplayName("паспорт")]
        [Required(ErrorMessage = "Введите серию и номер")]
        [StringLength(10, ErrorMessage = "Длинна не может быть более {1} символов")]
        public int ClientID { get; set; }

        [DisplayName("номер")]
        [Required(ErrorMessage = "Введите номер квартиры")]
        public int FlatID { get; set; }

        [ForeignKey("FlatID")]
        public Flat Flat { get; set; }

        [ForeignKey("ClientID")]
        public District Client { get; set; }

        [ForeignKey("SotrID")]
        public Sotrudnik Sotrudnik { get; set; }
    }
}
