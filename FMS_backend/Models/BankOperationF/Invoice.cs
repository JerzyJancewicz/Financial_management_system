namespace FMS_backend.Models.BankOperationF
{
    public class Invoice : BankOperation
    {
        public string Seller { get; set; } = string.Empty;
        public string Buyer { get; set; } = string.Empty;
        public HashSet<Receipt> Receipts {get; set; }
    }
}
