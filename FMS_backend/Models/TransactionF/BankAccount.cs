namespace FMS_backend.Models.TransactionF
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string BankName { get; set; } = string.Empty;
        public double Balance { get; set; }
        public string AccountNumber { get; set; } = string.Empty;

        public int BudgetId { get; set; }
        public Budget Budget { get; set; }
    }
}
