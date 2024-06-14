using FMS_backend.Models.BankOperationF;
using FMS_backend.Models.FinancialOperationF;
using FMS_backend.Models.UserF.Interfaces;

namespace FMS_backend.Models.UserF
{
    public class FinancialPerson : User, IAccountant, IFinancialSpecialist
    {
        public int NumberOfReports { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int NumberOfPredictions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Specialization { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Rank { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public HashSet<BankOperation> BankOperations { get; set; } = new HashSet<BankOperation>();
        public HashSet<FinancialReport> FinancialReports { get; set; } = new HashSet<FinancialReport>();
        public HashSet<FinancialPrediction> FinancialPredictions { get; set; } = new HashSet<FinancialPrediction>();

        public FinancialPerson()
        {

        }
    }
}
