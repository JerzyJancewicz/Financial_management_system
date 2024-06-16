using FMS_backend.Models.UserF;

namespace FMS_backend.Models.BankOperationF
{
    public class BankOperation
    {
        public int Id { get; set; }
        public double NetAmount { get; set; }
        public double GrossAmount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int FinancialPersonId { get; set; }
        public FinancialPerson FinancialPerson { get; set; }
        public void CountGrossAmount() 
        {
            GrossAmount = 0;
        }
    }
}
