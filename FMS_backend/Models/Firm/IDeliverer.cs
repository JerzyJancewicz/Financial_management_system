namespace FMS_backend.Models.Firm
{
    public interface IDeliverer
    {
        public DateTime DateOfRegistration{ get; set; }
        public double? Discount { get; set; }

        public void CountDiscount(DateTime dateOfRegistration);
    }
}
