using FMS_backend.Models.UserF;

namespace FMS_backend.Models.FinancialOperationF
{
    public class FinancialPlan : FinancialOperation
    {
        public int RiskValue { get; set; }
        public double PotentialIncome { get; set; }
        public bool IsRealised { get; set; }

        public ChiefOfFinance ChiefOfFinance { get; set; } = new ChiefOfFinance();
        public override void CountIncome(DateTime dateFrom, DateTime dateTo)
        {
            if (dateFrom > DateTo || dateTo < DateFrom)
            {
                Income = 0;
                return;
            }

            DateTime actualDateFrom = dateFrom > DateFrom ? dateFrom : DateFrom;
            DateTime actualDateTo = dateTo < DateTo ? dateTo : DateTo;

            double relevantDays = (actualDateTo - actualDateFrom).TotalDays + 1;

            double totalDays = (DateTo - DateFrom).TotalDays + 1;

            double dailyIncome = Income / totalDays;
            Income = dailyIncome * relevantDays;

            Income *= (1 - RiskValue / 100.0);
        }

        public void CountPotentialIncome()
        { 
            double dailyPotentialIncome = Income / ((DateTo - DateFrom).TotalDays + 1);
            PotentialIncome = dailyPotentialIncome * ((DateTo - DateFrom).TotalDays + 1) * (1 + RiskValue / 100.0);
        }
    }
}
