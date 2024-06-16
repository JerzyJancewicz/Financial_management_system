namespace FMS_backend.Models.TransactionF
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ProjectName { get; set; } = string.Empty;
        public double Balance { get; set; }
        public string? Description { get; set; }

        public HashSet<Transaction> Transactions { get; set; }
        public HashSet<BankAccount> BankAccounts { get; set; }
    }
}
