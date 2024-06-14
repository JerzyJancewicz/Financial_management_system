namespace FMS_backend.Models.BankOperationF
{
    public class Tax
    {
        public string Type { get; set; } = string.Empty;
        public double Rate { get; set; }
        public HashSet<Receipt> Receipts { get; set; } = new HashSet<Receipt>();
    }
}
