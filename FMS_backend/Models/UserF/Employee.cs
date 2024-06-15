using FMS_backend.Models.BankOperationF;

namespace FMS_backend.Models.UserF
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;

        public int ContactDetailsId { get; set; }
        public ContactDetails ContactDetails { get; set; } = new ContactDetails();

        public static double MinSal = 5000;

        public HashSet<Receipt> Receipts { get; set; } = new HashSet<Receipt>();
    }
}
