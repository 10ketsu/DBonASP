using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bober.Models.DatabaseModels
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("пaсспорт")]
        [Required(ErrorMessage = "серия и номер")]
        [StringLength(10, ErrorMessage = "Длинна фамилии не может быть более {1} символов")]
        public string Passport { get; set; }

        [DisplayName("введите дату рождения")]
        [Required(ErrorMessage = "день месяц год")]
        public DateTime DateBorn { get; set; }

        [DisplayName("укажите пол")]
        [Required(ErrorMessage = "Введите букву")]
        [StringLength(1, ErrorMessage = "Длинна не может быть более {1} символов")]
        public string Sex { get; set; }

        [DisplayName("телефон")]
        [Required(ErrorMessage = "Введите номер телефона")]
        [StringLength(11, ErrorMessage = "Длинна номера не может быть более {1} символов")]
        public string Phone { get; set; }

        //public List<Dogovor> Dogovors { get; set; }
    }
}
