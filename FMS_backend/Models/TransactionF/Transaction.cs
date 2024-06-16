using FMS_backend.Models.TransactionF.Types;
using FMS_backend.Models.UserF;

namespace FMS_backend.Models.TransactionF
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime OperationDate { get; set; }
        public double Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public StatusType StatusType { get; set; }

        public int BudgetId { get; set; }
        public Budget Budget { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
