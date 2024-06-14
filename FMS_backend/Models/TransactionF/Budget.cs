namespace FMS_backend.Models.TransactionF
{
    public class Budget
    {
        public string Name { get; set; } = string.Empty;
        public string ProjectName { get; set; } = string.Empty;
        public double Balance { get; set; }
        public string? Description { get; set; }

        public HashSet<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
        public HashSet<BankAccount> BankAccounts { get; set; } = new HashSet<BankAccount>();
    }
}
