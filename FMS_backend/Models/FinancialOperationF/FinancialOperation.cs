namespace FMS_backend.Models.FinancialOperationF
{
    public abstract class FinancialOperation
    {
        public string Name { get; set; } = string.Empty;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public double Income { get; set; }


        public abstract void CountIncome(DateTime dateFrom, DateTime dateTo);
    }
}
