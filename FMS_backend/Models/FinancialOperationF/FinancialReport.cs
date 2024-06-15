using FMS_backend.Models.UserF;

namespace FMS_backend.Models.FinancialOperationF
{
    public class FinancialReport : FinancialOperation
    {
        public int Id { get; set; }
        public double Turnover { get; set; }

        public int FinancialPersonId { get; set; }
        public FinancialPerson FinancialPerson { get; set; } = new FinancialPerson();
        public override void CountIncome(DateTime dateFrom, DateTime dateTo)
        {
            if (dateFrom > DateTo || dateTo < DateFrom)
            {
                Income = 0;
                return;
            }
            DateTime actualDateFrom = dateFrom > DateFrom ? dateFrom : DateFrom;
            DateTime actualDateTo = dateTo < DateTo ? dateTo : DateTo;

            double totalDays = (DateTo - DateFrom).TotalDays;
            double relevantDays = (actualDateTo - actualDateFrom).TotalDays;

            if (totalDays > 0)
            {
                Income = (relevantDays / totalDays) * Income;
            }
            else
            {
                Income = 0;
            }
        }
    }
}
