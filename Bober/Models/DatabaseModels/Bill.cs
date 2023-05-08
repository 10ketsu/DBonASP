using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bober.Models.DatabaseModels
{
    public class Bill
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("дата")]
        [Required(ErrorMessage = "Введите дату окончания")]
        public DateTime DateFinish { get; set; }

        [DisplayName("сумма")]
        [Required(ErrorMessage = "Введите сумму")]
        public decimal Summ { get; set; }

        [DisplayName("дата")]
        [Required(ErrorMessage = "Введите дату заключения")]
        public DateTime DateStart { get; set; }

        [DisplayName("договор")]
        [Required(ErrorMessage = "Введите номер договора")]
        public int DogovorID { get; set; }
        [ForeignKey("DogovorID")]

        public Dogovor Dogovor { get; set; }
    }
}
