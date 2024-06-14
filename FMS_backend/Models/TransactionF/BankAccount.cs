namespace FMS_backend.Models.TransactionF
{
    public class BankAccount
    {
        public string BankName { get; set; } = string.Empty;
        public double Balance { get; set; }
        public string AccountNumber { get; set; } = string.Empty;

        public Budget Budget { get; set; } = new Budget();
    }
}
