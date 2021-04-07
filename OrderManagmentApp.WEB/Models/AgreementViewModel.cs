using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace OrderManagmentApp.WEB.Models
{
    public class AgreementViewModel
    {
        [Display(Name ="Номер договора")]
        public int Id { get; set; }
        [Display(Name = "От ")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Товар")]
        [Required]
        public string Good { get; set; }
        [Display(Name = "Сумма")]
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Display(Name = "Клиент ")]
        public string Customer { get; set; }

        public int? OrderId { get; set; }
    }
}
