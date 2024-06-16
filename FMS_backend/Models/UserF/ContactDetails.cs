namespace FMS_backend.Models.UserF
{
    public class ContactDetails
    {
        public int Id { get; set; }

        public HashSet<PhoneNumber> PhoneNumbers { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
