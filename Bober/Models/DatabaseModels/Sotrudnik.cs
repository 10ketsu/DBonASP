using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bober.Models.DatabaseModels
{
    public class Sotrudnik
    {
        [Key]
        [DisplayName("табельный номер")]
        [Required(ErrorMessage = "Введите табельный номер")]
        public int ID { get; set; }

        [DisplayName("ФИО")]
        [Required(ErrorMessage = "Введите ФИО сотрудника")]
        public string Fio { get; set; }

        [DisplayName("пол")]
        [Required(ErrorMessage = "Введите пол")]
        public string Pol { get; set; }

        [DisplayName("возраст")]
        [Required(ErrorMessage = "Введите возраст")]
        public int Age { get; set; }

        [DisplayName("номер отдела")]
        [Required(ErrorMessage = "Введите номер отдела")]
        public int OtdelID { get; set; }

        [DisplayName("название отдела")]
        [Required(ErrorMessage = "Введите название отдела")]
        public string OtdelName { get; set; }

    }
}
