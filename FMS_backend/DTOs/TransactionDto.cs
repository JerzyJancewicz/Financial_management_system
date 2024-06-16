using FMS_backend.Models.TransactionF.Types;
using FMS_backend.Models.UserF;

namespace FMS_backend.DTOs
{
    public class TransactionDto
    {
        public DateTime OperationDate { get; set; }
        public double Amount { get; set; }
        public TransactionType TransactionTypes { get; set; }
        public StatusType StatusTypes { get; set; }

        //u
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
    }
}
