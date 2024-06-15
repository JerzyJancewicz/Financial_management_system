using FMS_backend.Models.TransactionF.Types;
using FMS_backend.Models.UserF;

namespace FMS_backend.Models.TransactionF
{
    public class Transaction
    {
        public DateTime OperationDate { get; set; }
        public double Amount { get; set; }
        public List<TransactionType> TransactionTypes { get; set; } = new List<TransactionType>();
        public List<StatusType> StatusTypes { get; set; } = new List<StatusType>();

        public int BudgetId { get; set; }
        public Budget Budget { get; set; } = new Budget();

        public int UserId { get; set; }
        public User User { get; set; } = new User();
    }
}
