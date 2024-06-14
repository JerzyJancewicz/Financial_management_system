using System.Transactions;

namespace FMS_backend.Models.UserF
{
    public class User
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;

        public HashSet<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
    }
}
