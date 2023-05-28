using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bober.Models.DatabaseModels
{
    public class Sotrudnik
    {
        [Key]
        [DisplayName("табельный номер")]
        [Required(ErrorMessage = "Введите табельный номер")]
        public int Id { get; set; }

        [DisplayName("ФИО")]
        [Required(ErrorMessage = "Введите ФИО сотрудника")]
        public string Fio { get; set; }

        [DisplayName("Пол")]
        [Required(ErrorMessage = "Введите пол")]
        public string Pol { get; set; }

        [DisplayName("Возраст")]
        [Required(ErrorMessage = "Введите возраст")]
        public int Age { get; set; }

        [DisplayName("Название отдела")]
        [Required(ErrorMessage = "Введите название отдела")]
        public string OtdelName { get; set; }

        public override string ToString()
        {
            return $"{Fio}";
        }
    }
}
