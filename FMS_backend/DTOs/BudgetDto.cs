using FMS_backend.Models.TransactionF;

namespace FMS_backend.DTOs
{
    public class BudgetDto
    {
        public string Name { get; set; } = string.Empty;
        public string ProjectName { get; set; } = string.Empty;
        public double Balance { get; set; }
        public string? Description { get; set; }
        public ICollection<TransactionDto> Transactions { get; set; } = new List<TransactionDto>();
        public ICollection<BankAccountDto> BankAccounts { get; set; } = new List<BankAccountDto>();
    }
}
