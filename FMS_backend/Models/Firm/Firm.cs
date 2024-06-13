namespace FMS_backend.Models.Firm
{
    public class Firm : IClient, IDeliverer
    {
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string NIP { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public TypeOfCustomer Type { get; set; }

        public DateTime DateOfRegistration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double? Discount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DateOfDelivery { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Firm()
        {
                
        }

        public void CountDiscount(DateTime dateOfRegistration)
        {
            throw new NotImplementedException();
        }
    }
}
