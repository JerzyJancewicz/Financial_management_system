using Microsoft.Extensions.Hosting;

namespace FMS_backend.Models.FinancialOperationF
{
    public class FinancialPrediction : FinancialOperation
    {
        public double Profit { get; set; }
        public override void CountIncome(DateTime dateFrom, DateTime dateTo)
        {
            if (dateFrom > DateTo || dateTo < DateFrom)
            {
                Income = 0;
                Profit = 0;
                return;
            }

            DateTime actualDateFrom = dateFrom > DateFrom ? dateFrom : DateFrom;
            DateTime actualDateTo = dateTo < DateTo ? dateTo : DateTo;

            double relevantDays = (actualDateTo - actualDateFrom).TotalDays + 1;
            double totalDays = (DateTo - DateFrom).TotalDays + 1;

            double dailyIncome = Income / totalDays;
            Income = dailyIncome * relevantDays;

            double costs = Income - Profit;
            double dailyCosts = costs / totalDays;
            double totalCosts = dailyCosts * relevantDays;
            Profit = Income - totalCosts;
        }
    }
}
