namespace OrderManagmentApp.BusinessLogic.Models
{
    public class OrderAgreement
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int AgreementId { get; set; }
        public Agreement Agreement { get; set; }
    }
}
