using FMS_backend.Models.BankOperationF;

namespace FMS_backend.Models.FirmF
{
    public class Firm : IClient, IDeliverer
    {
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string NIP { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public TypeOfCustomer Type { get; set; }

        public DateTime? DateOfRegistration { get; set; }
        public double? Discount { get; set; }
        public DateTime? DateOfDelivery { get; set; }

        public HashSet<Receipt> Receipts { get; set; } = new HashSet<Receipt>();

        public Firm()
        {
            if (Type == TypeOfCustomer.CLIENT) 
            {
                DateOfRegistration = DateTime.Now;
            }
            if (Type == TypeOfCustomer.DELIVERER) 
            {
                DateOfDelivery = DateTime.Now;
            }
        }

        public void CountDiscount(DateTime dateOfRegistration)
        {
            var year = dateOfRegistration.Year - DateTime.Now.Year;
            if (year >= 4) 
            {
                year = 4;
            }
            switch (year) 
            {
                case 1:
                    Discount = 5; break;
                case 2:
                    Discount = 10; break;
                case 3:
                    Discount = 15; break;
                case 4:
                    Discount = 20; break;
                default:
                    Discount = 0; break;
            }
        }
    }
}
