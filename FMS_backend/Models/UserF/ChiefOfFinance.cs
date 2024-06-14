using FMS_backend.Models.FinancialOperationF;

namespace FMS_backend.Models.UserF
{
    public class ChiefOfFinance : User
    {
        public DateTime DateOfEmployment { get; set; }
        public string FinancialScore { get; set; } = string.Empty;

        public HashSet<FinancialPlan> FinancialPlans { get; set; } = new HashSet<FinancialPlan>();
    }
}
