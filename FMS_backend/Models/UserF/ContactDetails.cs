namespace FMS_backend.Models.UserF
{
    public class ContactDetails
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();
        public HashSet<PhoneNumber> PhoneNumbers { get; set; } = new HashSet<PhoneNumber>();
        public string Email { get; set; } = string.Empty;
    }
}
