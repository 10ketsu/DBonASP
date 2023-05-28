using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Bober.Models.DatabaseModels
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Дата окончания")]
        [Required(ErrorMessage = "Введите дату окончания")]
        public DateTime DateFinish { get; set; }

        [DisplayName("Сумма")]
        [Required(ErrorMessage = "Введите сумму")]
        public decimal Summ { get; set; }

        [DisplayName("Дата заключения")]
        [Required(ErrorMessage = "Введите дату заключения")]
        public DateTime DateStart { get; set; }


        [DisplayName("Номер договора")]
        [Required(ErrorMessage = "Введите номер договора")]
        public int DogovorID { get; set; }
        [ForeignKey("DogovorID")]
        [ValidateNever]
        public Dogovor Dogovor { get; set; }
    }
}
