using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bober.Models.DatabaseModels
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("дата платежа")]
        [Required(ErrorMessage = "Введите дату платежа")]
        public DateTime PaymentDate { get; set; }

        [DisplayName("сумма")]
        [Required(ErrorMessage = "Введите сумму платежа")]
        public decimal PaymentSumm { get; set; }

        [DisplayName("номер счета")]
        [Required(ErrorMessage = "Введите номер счета")]
        public int BillID { get; set; }
        [ForeignKey("BillID")]
        [ValidateNever]
        public Bill Bill { get; set; }
    }
}
