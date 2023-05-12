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

        [DisplayName("дата оконачания")]
        [Required(ErrorMessage = "Введите дату окончания")]
        public DateTime DateFinish { get; set; }

        [DisplayName("сумма платежа")]
        [Required(ErrorMessage = "Введите сумму платежа")]
        public decimal BillSumm { get; set; }

        [DisplayName("дата платежа")]
        [Required(ErrorMessage = "Введите дату платежа")]
        public DateTime BillDate { get; set; }

        //[DisplayName("номер платежа")]
        //[Required(ErrorMessage = "Введите номер платежа")]
        //public string Bill { get; set; }

        [DisplayName("номер платежа")]
        [Required(ErrorMessage = "Введите номер платежа")]
        public int BillID { get; set; }
        [ForeignKey("BillID")]
        public Bill Bill { get; set; }
    }
}
