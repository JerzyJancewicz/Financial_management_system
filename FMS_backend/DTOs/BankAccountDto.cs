namespace FMS_backend.DTOs
{
    public class BankAccountDto
    {
        public string BankName { get; set; } = string.Empty;
        public double Balance { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
    }
}
