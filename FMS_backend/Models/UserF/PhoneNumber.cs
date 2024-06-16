namespace FMS_backend.Models.UserF
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;

        public int ContactDetailsId { get; set; }
        public ContactDetails ContactDetails { get; set; }

    }
}
